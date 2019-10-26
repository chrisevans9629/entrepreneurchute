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
    public class MentoringRequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MentoringRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MentoringRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentoringRequest>>> GetMentoringRequests()
        {
            return await _context.MentoringRequests.ToListAsync();
        }

        // GET: api/MentoringRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MentoringRequest>> GetMentoringRequest(int id)
        {
            var mentoringRequest = await _context.MentoringRequests.FindAsync(id);

            if (mentoringRequest == null)
            {
                return NotFound();
            }

            return mentoringRequest;
        }

        // PUT: api/MentoringRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMentoringRequest(int id, MentoringRequest mentoringRequest)
        {
            if (id != mentoringRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(mentoringRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentoringRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MentoringRequests
        [HttpPost]
        public async Task<ActionResult<MentoringRequest>> PostMentoringRequest(MentoringRequest mentoringRequest)
        {
            _context.MentoringRequests.Add(mentoringRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMentoringRequest", new { id = mentoringRequest.Id }, mentoringRequest);
        }

        // DELETE: api/MentoringRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MentoringRequest>> DeleteMentoringRequest(int id)
        {
            var mentoringRequest = await _context.MentoringRequests.FindAsync(id);
            if (mentoringRequest == null)
            {
                return NotFound();
            }

            _context.MentoringRequests.Remove(mentoringRequest);
            await _context.SaveChangesAsync();

            return mentoringRequest;
        }

        private bool MentoringRequestExists(int id)
        {
            return _context.MentoringRequests.Any(e => e.Id == id);
        }
    }
}