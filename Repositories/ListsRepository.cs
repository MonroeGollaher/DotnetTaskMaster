using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DotnetTaskMaster.Models;

namespace DotnetTaskMaster.Repositories
{
    public class ListsRepository
    {
        private readonly IDbConnection _db;

        private readonly string populateCreator = "SELECT list.*, profile.* FROM lists list INNER JOIN profiles profile ON list.creatorId = profile.id ";

        public ListsRepository(IDbConnection db)
        {
            _db = db;
        }
        public int Create(List newList)
        {
            string sql = @"
            INSERT INTO lists 
            (title, isActive, creatorId)
            VALUES
            (@Title, @IsActive, @CreatorId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newList);
        }
        public IEnumerable<List> GetLists()
        {
            string sql = populateCreator + "WHERE isActive = 1";
            return _db.Query<List, Profile, List>(sql, (list, profile) => {list.Creator = profile; return list; }, splitOn: "id");
        }
  }
}