﻿using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RealEstate.Reposistory
{
    public interface ISellerReposistory
    {
        public List<Seller> GetAll();

        public List<Seller> GetTop3();
        public List<Seller> GetTop4();

        public Seller GetById(int Id);

        public void DeleteAgent(Seller seller);

        public void EditingAgent(Seller seller);
    }

    public class SellerReposistory : ISellerReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        public SellerReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<Seller> GetAll()
        {
            return _ctx.Sellers.ToList();
        }

        public List<Seller> GetTop3()
        {
            return _ctx.Sellers.OrderByDescending(x => x.Id).Take(3).ToList();
        }
        public List<Seller> GetTop4()
        {
            return _ctx.Sellers.OrderByDescending(x => x.Id).Take(4).ToList();
        }

        public Seller GetById(int Id)
        {
            return _ctx.Sellers
                .Where(x => x.Id == Id)
                .Include(x => x.Posts)
                .ThenInclude(p => p.RealEstate).ThenInclude(real => real.Category)
                .Include(x => x.Posts)
                .ThenInclude(p => p.RealEstate).ThenInclude(real => real.Location)
                .Include(x => x.Posts)
                .ThenInclude(p => p.RealEstate).ThenInclude(real => real.ChuDauTu)
                .SingleOrDefault();
        }

        public void EditingAgent(Seller seller)
        {
            if (seller != null)
            {
                var existingAgent = _ctx.Sellers.Where(x => x.Id == seller.Id).FirstOrDefault();
                if (existingAgent != null)
                {
                    existingAgent.Id = seller.Id;
                    existingAgent.UserName = seller.UserName;
                    existingAgent.PassWord = seller.PassWord;
                    existingAgent.Phone = seller.Phone;
                    existingAgent.Address = seller.Address;
                    existingAgent.Email = seller.Email;
                    existingAgent.Name = seller.Name;

                    if (seller.ImageUpload != null && seller.ImageUpload.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(existingAgent.Image))
                        {
                            DeleteImage(existingAgent.Image);
                        }
                        existingAgent.Image = SaveImage(seller.ImageUpload);
                    }
                    _ctx.Attach(existingAgent);
                    _ctx.Entry(existingAgent).State = EntityState.Modified;
                    _ctx.SaveChanges();
                }
            }
        }
        public void DeleteAgent(Seller seller)
        {
            if (seller != null)
            {
                _ctx.Sellers.Remove(seller);
                _ctx.SaveChanges();
            }
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
    }
}
