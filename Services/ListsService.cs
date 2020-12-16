using System;
using System.Collections.Generic;
using DotnetTaskMaster.Models;
using DotnetTaskMaster.Repositories;
using DotnetTaskMaster.Models;

namespace DotnetTaskMaster.Services
{
  public class ListsService
  {
    private readonly ListsRepository _repo;

    public ListsService(ListsRepository repo)
    {
        _repo = repo;
    }
    public List CreateList(List newList)
    {
      newList.Id = _repo.Create(newList);
      return newList;
    }

    public IEnumerable<List> GetLists()
    {
      return _repo.GetLists();
    }
  }
}