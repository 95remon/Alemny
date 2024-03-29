﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using Online_Education.Models;

namespace Online_Education.Controllers
{
    public class CoursesController : ApiController
    {
        private LearningContext db = new LearningContext();


        // GET: api/Courses
        public IQueryable<Course> GetCourses()
        {
            return db.Courses;
        }

        public List<Course> GetCoursesByUserID(string id)
        {
            var coursesteached = db.Teach.Where(t => t.TeacherID == id).ToList();
            List<Course> courses = new List<Course>();
            for (int i = 0; i < coursesteached.Count(); i++)
            {
                courses.Add(coursesteached[i].Course);
            }
            return courses;

        }

        // GET: api/Courses/
        [ResponseType(typeof(IQueryable<Course>))]
        [Route("api/courses/{StgID}/{Sem}/{Subject}")]
        /* public async Task<IHttpActionResult> GetCourse(int StgID, semester Sem, string Subject)
         {
             List<Course> courses = await db.Courses.Where(c=>c.StageID==StgID&&c.Semester==Sem&&c.Name.ToLower()==Subject.ToLower()).ToListAsync();
             if (courses == null)
             {
                 return NotFound();
             }

             return Ok(courses);
         }
         */
        // GET: api/Courses/5
        //[Route("api/courses/{id}")]
        //[ResponseType(typeof(Course))]
        [Route("GetCourse/{id}")]
        public async Task<IHttpActionResult> GetCourse(int id)
        {
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourse()
        {

            Course course = new Course();
            string pathImage;
            var httpRequest = HttpContext.Current.Request;

            //Upload Image
            course.Code = httpRequest["Code"];
            var postedFile = httpRequest.Files["Image"];
            course.Name = httpRequest["Name"];
            course.Description = httpRequest["Description"];
            course.MaxDegree = int.Parse(httpRequest["MaxDegree"]);
            course.MinDegree = int.Parse(httpRequest["MinDegree"]);
            course.StageID = int.Parse(httpRequest["StageID"]);
            // semester sem =  (semester)Enum.Parse(typeof(semester), httpRequest["Semester"]);
            //course.Semester = sem;
            course.Semester = httpRequest["Semester"];
            //Custom filename
            if (postedFile != null)
            {
                pathImage = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                pathImage += DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                string filePath = "";

                filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + pathImage);
                pathImage = "http://localhost:51851/Content/Images/" + pathImage;

                course.Image = pathImage;
                postedFile.SaveAs(filePath);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400
            }
            try
            {
                Course oldCourse = db.Courses.FirstOrDefault(p => p.Code == course.Code);
                oldCourse.Name = course.Name;
                oldCourse.Description = course.Description;
                oldCourse.MaxDegree = course.MaxDegree;

                oldCourse.MinDegree = course.MinDegree;
                oldCourse.StageID = course.StageID;
                oldCourse.Semester = course.Semester;
                if (postedFile != null)
                {
                    oldCourse.Image = course.Image;
                }

                db.SaveChanges();

                return StatusCode(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400

            }

        }




        // POST: api/Courses
        [ResponseType(typeof(Course))]
        [HttpPost]
        public async Task<IHttpActionResult> PostCourse()
        {
            Course course = new Course();
            string pathImage;
            var httpRequest = HttpContext.Current.Request;



            //Upload Image
            var postedFile = httpRequest.Files["Image"];

            course.Code = httpRequest["Code"];
            course.Name = httpRequest["Name"];
            course.Description = httpRequest["Description"];
            course.MaxDegree = int.Parse(httpRequest["MaxDegree"]);
            course.MinDegree = int.Parse(httpRequest["MinDegree"]);
            course.StageID = int.Parse(httpRequest["StageID"]);
            //  semester sem = (semester)Enum.Parse(typeof(semester), httpRequest["Semester"]);
            course.Semester = httpRequest["Semester"];
            //course.Semester = sem;
            //Custom filename
            pathImage = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            pathImage += DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            string filePath = "";

            filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + pathImage);
            pathImage = "http://localhost:51851/Content/Images/" + pathImage;

            course.Image = pathImage;
            postedFile.SaveAs(filePath);




            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                db.Courses.Add(course);
                db.SaveChanges();

                Teach teach = new Teach();
                teach.CourseId = course.Id;
                teach.TeacherID = httpRequest["TeacherID"];

                db.Teach.Add(teach);

                db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            return Ok(course);//CreatedAtRoute("DefaultApi", new { id = course.Code }, course);
        }

        // DELETE: api/Courses/5
        //[ResponseType(typeof(Course))]
        //[HttpDelete , Route("api/Courses/{id}")]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            db.SaveChangesAsync();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(string id)
        {
            return db.Courses.Count(e => e.Code == id) > 0;
        }


        /**/

        [Route("AllCourses/{code}/{stageName}")]
        public List<CourseTeacherDTO> GetCoursesByCodeAndStage(string code, string stageName)
        {
            // get Id for Stage
            // Search by Course code and  StageID
            Stage s = db.Stages.FirstOrDefault(stage => stage.Name == stageName);

            var CoursesTeacher = from crs in db.Courses
                                 join teach in db.Teach on crs.Id equals teach.CourseId
                                 join teachers in db.Users on teach.TeacherID equals teachers.Id
                                 where crs.Code == code && crs.StageID == s.ID

                                 select new
                                 {
                                     crs,
                                     teachers.UserName
                                 };


            List<CourseTeacherDTO> crsTeachers = crsTeachers = new List<CourseTeacherDTO>();

            CourseTeacherDTO crsTeacherdto;


            foreach (var item in CoursesTeacher)
            {
                crsTeacherdto = new CourseTeacherDTO();

                crsTeacherdto.Course = item.crs;
                crsTeacherdto.TeacherName = item.UserName;

                crsTeachers.Add(crsTeacherdto);
            }


            return crsTeachers;

        }


    }
}