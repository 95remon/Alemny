using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Online_Education.Models;

namespace Online_Education.Controllers
{
    public class LessonsController : ApiController
    {
        private LearningContext db = new LearningContext();

        // GET: api/Lessons
        public IQueryable<Lesson> GetLessons()
        {
            return db.Lessons;
        }

        // GET: api/Lessons/5
        [ResponseType(typeof(Lesson))]
        public async Task<IHttpActionResult> GetLesson(int id)
        {
            Lesson lesson = await db.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        // PUT: api/Lessons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLesson(int id, Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lesson.ID)
            {
                return BadRequest();
            }

            db.Entry(lesson).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Lessons
        [ResponseType(typeof(Lesson))]
        public async Task<IHttpActionResult> PostLesson(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lessons.Add(lesson);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lesson.ID }, lesson);
        }

        // DELETE: api/Lessons/5
        [ResponseType(typeof(Lesson))]
        public async Task<IHttpActionResult> DeleteLesson(int id)
        {
            Lesson lesson = await db.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            db.Lessons.Remove(lesson);
            await db.SaveChangesAsync();

            return Ok(lesson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonExists(int id)
        {
            return db.Lessons.Count(e => e.ID == id) > 0;
        }
    }
}