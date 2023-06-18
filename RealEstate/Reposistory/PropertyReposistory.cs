﻿using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RealEstate.Migrations;

namespace RealEstate.Reposistory
{
    public interface IPropertyReposistory
    {
        public List<Property> GetAll();
      
        public void EditingProperty(Property property);
      
        public Property GetPropertyById(int id);

        public List<Property> SearchProperties(string name);
      
        public void DeleteProperty(Property property);
    }

    public class PropertyReposistory : IPropertyReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        public PropertyReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<Property> GetAll()
        {
            return _ctx.Properties.ToList();
        }

        public void EditingProperty(Property property)
        {
            if (property != null)
            {
                var existingProperty = _ctx.Properties.Where(x => x.Id == property.Id).FirstOrDefault();
                if (existingProperty != null)
                {
                    existingProperty.Id = property.Id;
                    existingProperty.Name = property.Name;
                    existingProperty.Price = property.Price;
                    existingProperty.CategoryId = property.CategoryId;
                    existingProperty.LocationId = property.LocationId;
                    existingProperty.ChuDauTuId = property.ChuDauTuId;

                    if (property.ImageUpload != null && property.ImageUpload.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(existingProperty.Image))
                        {
                            DeleteImage(existingProperty.Image);
                        }
                        existingProperty.Image = SaveImage(property.ImageUpload);
                    }
                    _ctx.Attach(existingProperty);
                    _ctx.Entry(existingProperty).State = EntityState.Modified;
                    _ctx.SaveChanges();
                }
            }
        }

        public Property GetPropertyById(int id)
        {
            return _ctx.Properties
                .Where(x => x.Id == id)
                .Include(x => x.Posts)
                .ThenInclude(post => post.Seller)
                .Include(x => x.Location)
                .Include(x => x.Category)
                .Include(x => x.ChuDauTu)
                .SingleOrDefault();
        }

        public List<Property> SearchProperties(string name)
        {
            var query = _ctx.Properties.AsNoTracking().AsQueryable();

            // Apply search filters
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            //if (!string.IsNullOrEmpty(dientich))
            //{
            //    query = query.Where(p => p.DienTich == dientich);
            //}

            // Execute the query and return the results
            return query
                .Include(x => x.Image)
                .Include(x => x.Category)
                .Include(x => x.Location)
                .Include(x => x.ChuDauTu).ToList();
        }

        private void DeleteImage(string imageName)
        {
            string imagePath = "C://Users//Admin//Desktop//Bài tập về nhà//17,6,2023//RealEstate//RealEstate//wwwroot//img";
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        private string SaveImage(IFormFile imageFile)
        {
            string uniqueFileName = null;

            if (imageFile != null && imageFile.Length > 0)
            {
                string uploadFolder = "C://Users//Admin//Desktop//Bài tập về nhà//17,6,2023//RealEstate//RealEstate//wwwroot//img";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public void DeleteProperty(Property property)
        {
            if (property != null)
            {
                _ctx.Properties.Remove(property);
                _ctx.SaveChanges();
            }
                .Include(x=>x.Category)
                .Include(x=>x.Location)
                .Include(x=>x.ChuDauTu).ToList();
        }
    }
}