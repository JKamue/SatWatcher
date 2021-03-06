﻿using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Dapper;
using SatWatcher.Satellites;

namespace SatWatcher.Data
{
    class SqLiteDb
    {
        private SQLiteConnection _dbConnection;

        public SqLiteDb()
        {
            var dbFilePath = "./sats.sqlite";
            if (!File.Exists(dbFilePath))
                CreateDB(dbFilePath);

            _dbConnection = new SQLiteConnection(string.Format(
                "Data Source={0};Version=3;", dbFilePath));
            _dbConnection.Open();
        }

        private void CreateDB(string dbFilePath)
        {
            SQLiteConnection.CreateFile(dbFilePath);

            var tmpConnection = new SQLiteConnection(string.Format(
                "Data Source={0};Version=3;", dbFilePath));
            tmpConnection.Open();

            tmpConnection.Execute(
                "CREATE TABLE \"satellites\" (\r\n\t\"id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"name\"\tTEXT NOT NULL,\r\n\t\"line1\"\tTEXT NOT NULL,\r\n\t\"line2\"\tTEXT NOT NULL,\r\n\tPRIMARY KEY(\"id\")\r\n);");

            tmpConnection.Execute(
                "CREATE TABLE \"location\" (\r\n\t\"lat\"\tREAL NOT NULL,\r\n\t\"lng\"\tREAL NOT NULL,\r\n\tPRIMARY KEY(\"lat\")\r\n);");

            tmpConnection.Execute("INSERT INTO location (lat, lng) VALUES (0,0)");

            tmpConnection.Close();
        }


        public List<Satellite> GetAllSatellites()
        {

            return _dbConnection.Query<Satellite>("SELECT * FROM satellites").ToList();
        }

        public void AddSatellite(Satellite sat)
        {
            _dbConnection.Execute("INSERT INTO satellites (id, name, line1, line2) Values (@id, @name, @line1, @line2)",
                new {id = sat.ID, name = sat.Name, line1 = sat.TleLine1, line2 = sat.TleLine2});
        }

        public void RemoveSatellite(Satellite sat)
        {
            _dbConnection.Execute("DELETE FROM satellites WHERE id = @id", new { id = sat.ID });
        }

        public void UpdateTle(TleLines tle)
        {
            _dbConnection.Execute("UPDATE satellites SET line1 = @line1, line2 = @line2 WHERE id = @id",
                new {id = tle.Id, line1 = tle.Line1, line2 = tle.Line2});
        }

        public Location GetPosition()
        {
           return _dbConnection.Query<Location>("SELECT lat, lng FROM location").ToList().First();
        }

        public void SetLocation(Location loc)
        {
            _dbConnection.Execute("UPDATE location SET lat = @lat, lng = @lng WHERE 1 = 1",
                new {lat = loc.lat, lng = loc.lng });
        }

        public struct Location
        {
            public decimal lat;
            public decimal lng;
            public Location(decimal lat, decimal lng)
            {
                this.lat = lat;
                this.lng = lng;
            }
        }
    }
}
