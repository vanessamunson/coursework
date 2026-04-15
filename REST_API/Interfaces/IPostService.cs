using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces;

public interface IPostService
{
    List<Post> GetAll();
    Post GetById(int id);
    void Add(CreatePostRequest request);
    void Update(int id, Post post);
    void DeleteById(int id);
}
