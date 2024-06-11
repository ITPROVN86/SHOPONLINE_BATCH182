﻿using ShopBusiness.Models;
using ShopDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository
{
    public class CategoryRepository: ICategoryRepository
    {
        public async Task Add(Category category)
        {
            await CategoryDAO.Instance.Add(category);
        }

        public async Task Delete(int id)
        {
            await CategoryDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var category = await CategoryDAO.Instance.GetCategoryAll();
            return category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await CategoryDAO.Instance.GetCategoryById(id);
        }
        public async Task Update(Category category)
        {
            await CategoryDAO.Instance.Update(category);
        }
        public async Task<bool> ChangeStatus(int id)
        {
            return await CategoryDAO.Instance.ChangeStatus(id);
        }
    }
}
