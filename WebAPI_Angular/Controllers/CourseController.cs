﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_Angular.Models;
using System.Web.Configuration;


namespace WebAPI_Angular.Controllers
{
    public class CourseController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: api/Course
        public IQueryable<Course> GetCourses()
        {
            return db.Courses;
        }

        // GET: api/Course/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Course/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(int id, [FromBody] Course course)
        {


            if (id != course.ID)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Course
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse([FromBody] Course course)
        {
            if (course.EndDate <= course.StartDate)
            {
                string errMsg = WebConfigurationManager.AppSettings["EndDateError"];

                return CreatedAtRoute("EndDateNotValid", null, "{\"err\":\"true\", \"msg\":\"" + errMsg + "\"}");
            }
            db.Courses.Add(course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = course.ID }, course);
        }

        // DELETE: api/Course/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

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

        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.ID == id) > 0;
        }
    }
}