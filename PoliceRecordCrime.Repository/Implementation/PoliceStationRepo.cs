using Microsoft.EntityFrameworkCore;
using PoliceRecordCrime.Models;
using PoliceRecordCrime.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecordCrime.Repository.Implementation
{
    public class PoliceStationRepo : IPoliceStationRepo
    {
        private readonly ApplicationDbContext _context;//db ekeleme silme güncelleme ve listeleme islemlerine erisim icin kullancagiz.
                                                       //Bu kisim yazildiktan sonra PliceRecordCrime.Web altintaki Program.cs de tanimalam yapacagiz.

        public PoliceStationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(PoliceStation policeStation)
        {
            await _context.PoliceStations.AddAsync(policeStation);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var policeStation=await GetById(id);
            _context.PoliceStations.Remove(policeStation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PoliceStation>> GetAll(int page, int pageSize)
        {
           return await _context.PoliceStations.OrderBy(p=>p.Name).Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<PoliceStation> GetById(int id)
        {
            return await _context.PoliceStations.FindAsync(id);
        }

        public async Task Update(PoliceStation policeStation)
        {
            _context.Entry(policeStation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Count(int id)
        {
            return await _context.PoliceStations.CountAsync();
        }
    }
}
