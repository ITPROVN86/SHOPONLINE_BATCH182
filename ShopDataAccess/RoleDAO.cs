using Microsoft.EntityFrameworkCore;
using ShopBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDataAccess
{
    public class RoleDAO : SingletonBase<RoleDAO>
    {
        /// <summary>
        /// GET ALL
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetRoleAll()
        {
            return _context.Roles.AsNoTrackingWithIdentityResolution().ToList();
        }

        /// <summary>
        /// GET BY ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRoleById(int id)
        {
            var role = _context.Roles.AsNoTrackingWithIdentityResolution().FirstOrDefault(c => c.RoleId == id);
            if (role == null) return null;

            return role;
        }
        public void Add(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }
        public void Update(Role role)
        {
            _context = new ShopBacth182Context();
            var existingItem = GetRoleById(role.RoleId);
            if (existingItem != null)
            {
                // Cập nhật các thuộc tính cần thiết
                _context.Entry(existingItem).CurrentValues.SetValues(role);
            }
            else
            {
                // Thêm thực thể mới nếu nó chưa tồn tại
                _context.Roles.Add(role);
            }
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var role = GetRoleById(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
