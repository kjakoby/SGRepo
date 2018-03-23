using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                //if (studentVM.Student.GPA<0 || studentVM.Student.GPA>5)
                //{
                //    var viewModel = new StudentVM();
                //    viewModel.SetCourseItems(CourseRepository.GetAll());
                //    viewModel.SetMajorItems(MajorRepository.GetAll());
                //    viewModel.SetStateItems(StateRepository.GetAll());

                //    return View("Add", viewModel);
                //}
                //else
                //{
                    studentVM.Student.Courses = new List<Course>();
                    studentVM.Student.Address = new List<Address>();
                    AddressVM address = new AddressVM();
                    foreach (var courseID in studentVM.SelectedCourseIds)
                        studentVM.Student.Courses.Add(CourseRepository.Get(courseID));

                    studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                    Student modelStudent = studentVM.Student;
                    //Student student = new Student();
                    //student.FirstName = modelStudent.FirstName;
                    //student.LastName = modelStudent.LastName;
                    //student.Courses = modelStudent.Courses;
                    //student.GPA = modelStudent.GPA;
                    //student.Major = modelStudent.Major;
                    int id2 = StudentRepository.Add(modelStudent);
                    address.Student = studentVM.Student;
                    //StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);

                    //return RedirectToAction(/*"List"*/"AddAddress", address.Student/*.StudentId*/);
                    return RedirectToAction(/*"List"*/"AddAddress", new { id = id2 }/*.StudentId*/);
                //}
                
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                viewModel.SetStateItems(StateRepository.GetAll());

                return View("Add", viewModel);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = StudentRepository.Get(id);
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());

            viewModel.Student = student;

            foreach (var course in student.Courses)
                viewModel.SelectedCourseIds.Add(course.CourseId);

            //selectedStudent.FirstName = student.FirstName;
            //selectedStudent.LastName = student.LastName;
            //selectedStudent.Major = student.Major;
            //selectedStudent.GPA = student.GPA;
            //selectedStudent.Courses = student.Courses;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                //StudentRepository.Edit(studentVM.Student);
                int id2 = StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List", new { id = id2 });
            }
            else
            {
                var student = StudentRepository.Get(studentVM.Student.StudentId);
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());

                viewModel.Student = student;

                foreach (var course in student.Courses)
                    viewModel.SelectedCourseIds.Add(course.CourseId);
                return View("Edit", viewModel);
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            StudentRepository.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult StudentAddress(int id)
        {
            var model = StudentRepository.Get(id);
            var viewModel = new StudentVM();
            //var foundAddressList = model.Address;
            viewModel.Student = model;
            //viewModel.Student.Address = new List<Address>();
            //var emptyStarter = viewModel.Student.Address;
            //emptyStarter.AddRange(model.Address);
            //if (model.Address.Count()==0)
            //{
            //    //return new EmptyResult();
            //}
            //else
            //{
            //if (viewModel.Student.Address.Count()!=0)
            //{

            //if (emptyStarter.Count() != 0)
            //{
                //foreach (var address in model.Address)
                //{

                //    viewModel.Student.Address.Add(address);

                //}
            //}

            //}
            return View(viewModel.Student);
            //}


        }

        [HttpGet]
        public ActionResult AddAddress(int id)
        {
            var currentStudent = StudentRepository.Get(id);
            var viewModel = new AddressVM();
            viewModel.Student = currentStudent;
            //viewModel.SetStateItems(StateRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddAddress(AddressVM addressVM)
        {
            //studentVM.Student.Address = new List<Address>();
            //var student = StudentRepository.Get(addressVM.Student.StudentId);
            //var student = addressVM.Student;
            //var viewModel = new AddressVM();
            //foreach (var address in student.Address)
            //{
            //    viewModel.Address = address;
            //}
            //viewModel.Student=student;
            StudentRepository.SaveAddress(addressVM.Student.StudentId,addressVM.Address);
            //StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);

            return RedirectToAction("StudentAddress", new { id= addressVM.Student.StudentId });
        }

        //[HttpGet]
        //public ActionResult DeleteAddress(int id)
        //{
        //    var currentStudent = StudentRepository.Get(id);
        //    var viewModel = new AddressVM();
        //    viewModel.Student = currentStudent;
        //    //viewModel.SetStateItems(StateRepository.GetAll());
        //    return View(viewModel);
        //}

        [HttpPost]
        public ActionResult DeleteAddress(AddressVM addressVM,int studentId, int addressId)
        {
            //StudentRepository.DeleteAddress(addressVM.Student.StudentId, addressVM.Address);
            var student = StudentRepository.Get(studentId);
            Address address = student.Address.Where(a => a.AddressId == addressId).FirstOrDefault();
            student.Address.Remove(address);
            return RedirectToAction("StudentAddress", new { id = studentId });
        }

        [HttpGet]
        public ActionResult EditAddress(int studentId, int addressId)
        {
            var currentStudent = StudentRepository.Get(studentId);
            var viewModel = new AddressVM();
            viewModel.Student = currentStudent;
            viewModel.Address = currentStudent.Address.Where(a => a.AddressId == addressId).FirstOrDefault();
            viewModel.Address.AddressId = addressId;
            //viewModel.SetStateItems(StateRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditAddress(AddressVM addressVM, int studentId)
        {
            //studentVM.Student.Address = new List<Address>();
            //var student = StudentRepository.Get(addressVM.Student.StudentId);
            //var student = addressVM.Student;
            //var viewModel = new AddressVM();
            //foreach (var address in student.Address)
            //{
            //    viewModel.Address = address;
            //}
            //viewModel.Student=student;
            //StudentRepository.SaveAddress(addressVM.Student.StudentId, addressVM.Address);
            //StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
            var student = StudentRepository.Get(studentId);
            addressVM.Student = student;
            //var currentAddress = student.Address.Where(a => a.AddressId == addressVM.Address.AddressId).First();
            var currentAddress = addressVM.Address;
            int prevId = StudentRepository.EditAddress(addressVM.Address.AddressId, currentAddress, student);
            //StudentRepository.SaveAddress(addressVM.Student.StudentId, addressVM.Address);
            return RedirectToAction("StudentAddress", new { id = prevId });
        }
    }
}