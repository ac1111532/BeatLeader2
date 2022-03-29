﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeatLeader2.Models;

namespace BeatLeader2.Views
{
    public class BeatmapsController : Controller
    {
        private readonly BeatLeader2ContextDb _context;

        public BeatmapsController(BeatLeader2ContextDb context)
        {
            _context = context;
        }

        // GET: Beatmaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beatmap.ToListAsync());
        }

        // GET: Beatmaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beatmap = await _context.Beatmap
                .FirstOrDefaultAsync(m => m.BeatmapID == id);
            if (beatmap == null)
            {
                return NotFound();
            }

            return View(beatmap);
        }

        // GET: Beatmaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beatmaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeatmapID,Notes,Walls,Bombs,Slash,MapPlays")] Beatmap beatmap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beatmap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beatmap);
        }

        // GET: Beatmaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beatmap = await _context.Beatmap.FindAsync(id);
            if (beatmap == null)
            {
                return NotFound();
            }
            return View(beatmap);
        }

        // POST: Beatmaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeatmapID,Notes,Walls,Bombs,Slash,MapPlays")] Beatmap beatmap)
        {
            if (id != beatmap.BeatmapID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beatmap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeatmapExists(beatmap.BeatmapID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beatmap);
        }

        // GET: Beatmaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beatmap = await _context.Beatmap
                .FirstOrDefaultAsync(m => m.BeatmapID == id);
            if (beatmap == null)
            {
                return NotFound();
            }

            return View(beatmap);
        }

        // POST: Beatmaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beatmap = await _context.Beatmap.FindAsync(id);
            _context.Beatmap.Remove(beatmap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeatmapExists(int id)
        {
            return _context.Beatmap.Any(e => e.BeatmapID == id);
        }
    }
}
