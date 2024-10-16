using DAOControllers.ManagerControllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using UniversityFront.Models;

namespace UniversityFront.Controllers
{
    public class StudentController(ILogger<StudentController> logger,
            IGenericRepository<Student> student) : Controller
    {
        private readonly ILogger<StudentController> _logger = logger;
        private readonly IGenericRepository<Student> _studentRepository = student;
     
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> listStudents = await _studentRepository.getAll();

            StudentCourseViewModel model = new()
            {
                students = listStudents,
                courses = new List<Course>()
            };

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lastName", "firstMidName", "genre", "img")] StudentViewModel studentVM)
        {
            Student student = new Student();

                try
                {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        FileInfo fileInfo = new FileInfo(studentVM.img.FileName);
                        string fileName = studentVM.lastName + "_" + studentVM.firstMidName + fileInfo.Extension;

                        string filePath = Path.Combine(path, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await studentVM.img.CopyToAsync(stream);
                        }


                        int id = await _studentRepository.getMaxId();

                        if (id != 0)
                        {
                            student.idStudent = id;
                            student.lastName = studentVM.lastName;
                            student.firstMidName = studentVM.firstMidName;
                            student.genre = studentVM.genre;
                            //student.img = System.IO.File.ReadAllBytes(filePath);
                            student.img = imageConversion(filePath);
                        }

                        int result = await _studentRepository.create(student);

                        if (result != 0)
                        {
                            Console.WriteLine(Ok(studentVM));
                            return RedirectToAction(nameof(Index));
                        }
                        else 
                        {
                            Console.WriteLine(BadRequest(studentVM));
                        }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }  

            return View("Create", studentVM);
        }

        public static byte[] imageConversion(string imagePath)
        {

            //Initialize a file stream to read the image file
            FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

            //Initialize a byte array with size of stream
            byte[] imgByteArr = new byte[fs.Length];

            //Read data from the file stream and put into the byte array
            fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

            //Close a file stream
            fs.Close();

            return imgByteArr;
        }

    }//End student controller
}//End namespace university front
