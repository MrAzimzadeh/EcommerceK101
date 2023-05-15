using EcommerceK101.Areas.Dashboard.ViewModels;
using EcommerceK101.Helpers;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class TeaamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeaamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var list = _context.Teams.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            try
            {
                var social = _context.SocialNetworks.ToList();
                ViewData["socials"] = social;


                var position = _context.Positions.ToList();
                ViewBag.positions = new SelectList(position, "Id", "PositionName");

                return View();

            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team, IFormFile Photo, List<int> socialId, List<string> socialUrl)
        {
            try
            {
                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();
                var photo = ImageHelper.UploadSinglePhoto(Photo, _env);
                team.PhotoUrl = photo;
                for (int i = 0; i < socialId.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(socialUrl[i]))
                    {
                        TeamsNetwork tn = new()
                        {
                            TeamId = team.Id,
                            SocialNetworkId = socialId[i],
                            UserUrl = socialUrl[i],
                        };
                        await _context.TeamsNetworks.AddAsync(tn);
                        await _context.SaveChangesAsync();
                    }
                }
                //var position = _context.Positions.ToList();
                //ViewData["position"] = position;

                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delete = _context.Teams.FirstOrDefault(c => c.Id == id);
            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var detail = _context.Teams.Include(x => x.Position).Include(x => x.TeamsNetworks).ThenInclude(x => x.SocialNetwork).FirstOrDefault(x => x.Id == id);
            return View(detail);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _context.Teams
                .Include(x => x.Position)
                .Include(x => x.TeamsNetworks)
                .ThenInclude(x => x.SocialNetwork)
                .FirstOrDefault(x => x.Id == id);
            var social = _context.SocialNetworks.ToList();
            ViewData["socials"] = social;
            var position = _context.Positions.ToList();
            ViewBag.positions = new SelectList(position, "Id", "PositionName");
            var teamNetwork = _context.TeamsNetworks.Where(x => x.UserUrl != null).ToList();
            TeamVM vm = new()
            {
                Team = edit,
                SocialNetworks = social,
                TeamsNetworks = teamNetwork,
                Positions = position
            };


            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(Team team, IFormFile Photo, List<int> socialId, List<string> socialUrl)
        {
            try
            {
                if (Photo != null)
                {
                    var photo = ImageHelper.UploadSinglePhoto(Photo, _env);
                    team.PhotoUrl = photo;
                }

                List<TeamsNetwork> teamsNetworks = new List<TeamsNetwork>();
                for (int i = 0; i < socialId.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(socialUrl[i]))
                    {
                        TeamsNetwork tn = new TeamsNetwork()
                        {
                            SocialNetworkId = socialId[i],
                            UserUrl = socialUrl[i]
                        };
                        teamsNetworks.Add(tn);
                    }
                }

                team.TeamsNetworks = teamsNetworks;
                _context.Teams.Update(team);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }









    }
}

