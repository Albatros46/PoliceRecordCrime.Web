using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PoliceRecordCrime.Models;
using PoliceRecordCrime.Repository.Interfaces;
using PoliceRecordCrime.ViewModels;

namespace PoliceRecordCrime.Web.Controllers
{
    public class PoliceStationController : Controller
    {
        private readonly IPoliceStationRepo _policeStationRepo;
        private const int PageSize = 10;

        public PoliceStationController(IPoliceStationRepo policeStationRepo)
        {
            _policeStationRepo = policeStationRepo;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var policeStation = await _policeStationRepo.GetAll(page, PageSize);
            var viewModel = new PoliceStationIndexViewModel
            {
                PoliceStations = policeStation,
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = await _policeStationRepo.Count(page),
                }
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PoliceStationViewModel policeStationViewModel)
        {
            if (ModelState.IsValid)
            {
                var policeStation = new PoliceStation { Name = policeStationViewModel.Name, Location = policeStationViewModel.Location };
                await _policeStationRepo.Add(policeStation);
                return RedirectToAction("Index");
            }
            return View(policeStationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var policeSation = await _policeStationRepo.GetById(id);
            if (policeSation == null)
            {
                return NotFound();
            }
            var policeStationViewModel = new PoliceStationViewModel
            {
                Name = policeSation.Name,
                Location = policeSation.Location
            };
            return View(policeStationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PoliceStationViewModel policeStationViewModel)
        {
            if (ModelState.IsValid)
            {
                var policeStation = await _policeStationRepo.GetById(policeStationViewModel.Id);
                if (policeStation == null)
                {
                    return NotFound();
                }
                policeStation.Name = policeStationViewModel.Name;
                policeStation.Location = policeStationViewModel.Location;

                await _policeStationRepo.Update(policeStation);
                return RedirectToAction("Index");
            }
            return View(policeStationViewModel);
        }
    }
}
