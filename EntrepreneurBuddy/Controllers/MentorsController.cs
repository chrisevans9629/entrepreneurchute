﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntrepreneurBuddy.Models;

namespace EntrepreneurBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MentorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Mentors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mentor>>> GetMentors()
        {
            return await _context.Mentors.ToListAsync();
        }

        // GET: api/Mentors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mentor>> GetMentor(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);

            if (mentor == null)
            {
                return NotFound();
            }

            return mentor;
        }



        [HttpPost("{id}/Like")]
        public async Task<IActionResult> PutLike(int id)
        {
            var mentor = _context.Mentors.FirstOrDefault(p => p.Id == id);
            mentor.Rating++;
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }


        // PUT: api/Mentors/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMentor(int id, Mentor mentor)
        //{
        //    if (id != mentor.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(mentor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MentorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Mentors
        //[HttpPost]
        //public async Task<ActionResult<Mentor>> PostMentor(Mentor mentor)
        //{
        //    _context.Mentors.Add(mentor);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMentor", new { id = mentor.Id }, mentor);
        //}

        // DELETE: api/Mentors/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Mentor>> DeleteMentor(int id)
        //{
        //    var mentor = await _context.Mentors.FindAsync(id);
        //    if (mentor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Mentors.Remove(mentor);
        //    await _context.SaveChangesAsync();

        //    return mentor;
        //}

        private bool MentorExists(int id)
        {
            return _context.Mentors.Any(e => e.Id == id);
        }
    }
}
