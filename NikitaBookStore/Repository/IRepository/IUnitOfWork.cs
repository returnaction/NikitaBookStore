﻿namespace NikitaBookStore.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IBookRepository Book { get; }

        void Save();
    }
}
