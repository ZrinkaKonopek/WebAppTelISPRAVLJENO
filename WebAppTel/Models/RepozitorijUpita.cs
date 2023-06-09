using System;
using WebAppTel.Controllers;
using Microsoft.EntityFrameworkCore;

namespace WebAppTel.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Mobitel mobitel)
        {
            _appDbContext.Add(mobitel);
            _appDbContext.SaveChanges();
        }

        public void Create(Marka marka)
        {
            _appDbContext.Add(marka);
            _appDbContext.SaveChanges();
        }

        public void Delete(Mobitel mobitel)
        {
            _appDbContext.Mobitel.Remove(mobitel);
            _appDbContext.SaveChanges();
        }

        public void Delete(Marka marka)
        {
            _appDbContext.Marka.Remove(marka);
            _appDbContext.SaveChanges();
        }

        public Mobitel DohvatiMobitelSIdom(int id) 
        {
            return _appDbContext.Mobitel
                .Include(m =>m.Marka)
                .FirstOrDefault(m => m.Id == id);   
        }

        public Marka DohvatiMarkuSIdom(int id) 
        {
            return _appDbContext.Marka.Find(id);
        }

        public int MarkaSljedeciId()
        {
            int zadnjiId = _appDbContext.Marka.Select(m => m.Id).Max();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public IEnumerable<Mobitel> PopisMobitel()
        {

            return _appDbContext.Mobitel.Include(m => m.Marka);
        }

        public IEnumerable<Marka> PopisMarka()
        {
            return _appDbContext.Marka;
        }
        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Mobitel
                .Include(m => m.Marka)
                .Max(x => x.Id);

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Mobitel mobitel)
        {
            _appDbContext.Mobitel.Update(mobitel);
            _appDbContext.SaveChanges();
        }

        public void Update(Marka marka)
        {
            _appDbContext.Marka.Update(marka);
            _appDbContext.SaveChanges();
        }
    }
}