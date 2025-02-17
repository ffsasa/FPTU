- Bước 1: Tạo Blank solution
- Bước 2: Tạo library Repository
- Bước 3: Chạy các câu lệnh này trong terminal của Repository
	dotnet add package Microsoft.EntityFrameworkCore --version 8.0.5
	dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.5
	dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.5
	dotnet add package Microsoft.Extensions.Configuration --version 8.0.0
	dotnet add package Microsoft.Extensions.Configuration.Json --version 8.0.0
- Bước 4: Add database 
- Bước 5: Sử dụng thằng EF core power tool để add database thay cho thằng scaffold vào thẳng Repository nhớ chọn Reverse Engineer, chọn add và trong box thì tick vào Trust Server Certificate và sử dụng SQL Server Authenticate
- Bước phụ 5: Chọn đúng 3 bảng cần làm bài, sau đó tick vào ô Include connection string ... ở box tiếp theo
- Bước 6: Chuyển connectionstring vào appsetting.json và sửa lại trong DBcontext, =====> NHỚ COPY LẠI CONNECTION ĐỂ ADD VÀO APPSETTING.JSON

public static string GetConnectionString(string connectionStringName)
{
    var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

    string connectionString = config.GetConnectionString(connectionStringName);
    return connectionString;
}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

- Bước 7: Tạo folder DBContext trong Repository kéo thằng DBContext vào và thêm using model vào DBContext và sửa NameSpace cho đúng với NameSpace mới
- Bước 8: Tạo folder Base trong Repository và thêm class GenericRepository và copy code như sau:	
		    ********NHỚ SỬA ĐÚNG LẠI DBCONTEXT CỦA DỰ ÁN********

public class GenericRepository<T> where T : class
{
    protected zPaymentContext _context;

    public GenericRepository()
    {
        _context ??= new zPaymentContext();
    }

    public GenericRepository(zPaymentContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public void Create(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public async Task<int> CreateAsync(T entity)
    {
        _context.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        var tracker = _context.Attach(entity);
        tracker.State = EntityState.Modified;
        _context.SaveChanges();

        //if (_context.Entry(entity).State == EntityState.Detached)
        //{
        //    var tracker = _context.Attach(entity);
        //    tracker.State = EntityState.Modified;
        //}
        //_context.SaveChanges();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        //var trackerEntity = _context.Set<T>().Local.FirstOrDefault(e => e == entity);
        //if (trackerEntity != null)
        //{
        //    _context.Entry(trackerEntity).State = EntityState.Detached;
        //}
        //var tracker = _context.Attach(entity);
        //tracker.State = EntityState.Modified;
        //return await _context.SaveChangesAsync();

        var tracker = _context.Attach(entity);
        tracker.State = EntityState.Modified;
        return await _context.SaveChangesAsync();

        //if (_context.Entry(entity).State == EntityState.Detached)
        //{
        //    var tracker = _context.Attach(entity);
        //    tracker.State = EntityState.Modified;
        //}

        //return await _context.SaveChangesAsync();
    }

    public bool Remove(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public async Task<bool> RemoveAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public T GetById(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;

        //return _context.Set<T>().Find(id);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;

        //return await _context.Set<T>().FindAsync(id);
    }

    public T GetById(string code)
    {
        var entity = _context.Set<T>().Find(code);
        if (entity != null)
        {
		_context.Entry(entity).State = EntityState.Detached;
        }

        return entity;

        //return _context.Set<T>().Find(code);
    }

    public async Task<T> GetByIdAsync(string code)
    {
        var entity = await _context.Set<T>().FindAsync(code);
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;

        //return await _context.Set<T>().FindAsync(code);
    }

    public T GetById(Guid code)
    {
        var entity = _context.Set<T>().Find(code);
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;

        //return _context.Set<T>().Find(code);
    }

    public async Task<T> GetByIdAsync(Guid code)
    {
        var entity = await _context.Set<T>().FindAsync(code);
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;

        //return await _context.Set<T>().FindAsync(code);
    }

    #region Separating asigned entity and save operators        

    public void PrepareCreate(T entity)
    {
        _context.Add(entity);
    }

    public void PrepareUpdate(T entity)
    {
        var tracker = _context.Attach(entity);
        tracker.State = EntityState.Modified;
    }

    public void PrepareRemove(T entity)
    {
        _context.Remove(entity);
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    #endregion Separating asign entity and save operators
}

- Bước 9: Tạo Repository để PUBLIC và kế thừa thằng GenericRepository<*Tên entity*> và nếu có method nào cần thêm ngoài các method cơ bản thì viết thêm vào đây
public class SurveyRepository : GenericRepository<Survey>
{
    public SurveyRepository() { }

    public async Task<List<Survey>> SearchAsync(string Name, int Number, int Verygood)
    {
        return await _context.Surveys
            .Include(u => u.Category)
            .Where(u => u.Category.Name == Name &&
                        u.Number >= Number && 
                        u.Verygood >= Verygood)
            .ToListAsync();
    }
}


- Bước10: Viết IService và Service cùng 1 nơi:
    public interface ISurveyService
    {
        Task<List<Survey>> GetAll();
        Task<Survey> GetById(int id);
        Task<int> Create(Survey survey);
        Task<int> Update(Survey survey);
        Task<bool> Delete(int id);
        Task<List<Survey>> SearchAsync(string Name, int Number, int Verygood);
    }

    public class SurveyService : ISurveyService
    {
        private readonly SurveyRepository _surveyRepository;
        public SurveyService()
        {
            _surveyRepository = new SurveyRepository();
        }

        public async Task<int> Create(Survey survey)
        {
            return await _surveyRepository.CreateAsync(survey);
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _surveyRepository.GetByIdAsync(id);
            if (item != null)
            {
                return await _surveyRepository.RemoveAsync(item);
            }
            return false;
        }

        public async Task<List<Survey>> GetAll()
        {
            return await _surveyRepository.GetAllAsync();
        }

        public async Task<Survey> GetById(int id)
        {
            return await _surveyRepository.GetByIdAsync(id);
        }

        public async Task<List<Survey>> SearchAsync(string Name, int Number, int Verygood)
        {
            return await _surveyRepository.SearchAsync(Name, Number, Verygood);
        }

        public async Task<int> Update(Survey survey)
        {
            return await _surveyRepository.UpdateAsync(survey);
        }
    }

Bước 11: Tạo project mới kiểu ASP.NET Core Web API và Add vào Program như sau:
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});

Bước 12: Viết tạo appsettings trong project API:
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=DESKTOP-75RNH8M\\AN;Initial Catalog=NET1720_PRN231_PRJ_G1_SchoolPsychologicalHealthSupportSystem;Persist Security Info=True;User ID=sa;Password=12345;Encrypt=False"
  }
}

Bước 13: Tạo controller bằng cách => Chọn new scaffolded Item trong add của controller và chọn API Controller read/write action và viết controller như sau, tương tự với các controller khác:

namespace Psychological_APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // GET: api/<SurveyController>
        [HttpGet]
        public async Task<IEnumerable<Survey>> Get()
        {
            return await _surveyService.GetAll();
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SurveyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SurveyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SurveyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


Bước 14: Thêm phần sau vào appsetting, chỉnh đúng localhost
  "Jwt": {
    "Key": "0ccfeb299b126a479a64630e2d34e9e91e5fcbcaea8ac9e3347e224b0557a53e",
    "Issuer": "https://localhost:7075",
    "Audience": "https://localhost:7075"
  }

Bước 15: dotnet add package  Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.10
Add vào APIService

Bước 16: Thêm phần sau vào program.cs của APIService, config những gì jwt sẽ check:
////JWT Config
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

Và
app.UseHttpsRedirection();
app.UseAuthorization();


Bước 17: Viết thêm vào UserAccountController của APIService phần sau:

private readonly IConfiguration _config;
private readonly SystemUserAccountsService _userAccountsService;

public SystemUserAccountsController(IConfiguration config, SystemUserAccountsService userAccountsService)
{
    _config = config;
    _userAccountsService = userAccountsService;
}

[HttpPost("Login")]
public IActionResult Login([FromBody] LoginReqeust request)
{
    var user = _userAccountsService.Authenticate(request.UserName, request.Password);

    if (user == null || user.Result == null)
        return Unauthorized();
    
    var token = GenerateJSONWebToken(user.Result);

    return Ok(token);
}

private string GenerateJSONWebToken(SystemUserAccount systemUserAccount)
{
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(_config["Jwt:Issuer"]                    
            , _config["Jwt:Audience"]
            , new Claim[]
            {
                new(ClaimTypes.Name, systemUserAccount.UserName),
                //new(ClaimTypes.Email, systemUserAccount.Email),
                new(ClaimTypes.Role, systemUserAccount.RoleId.ToString()),                        
            },
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials                
        );

    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

    return tokenString;
}

public sealed record LoginReqeust(string UserName, string Password);


Bước 18: Thêm phần sau vào Program.cs của APIService:
builder.Services.AddSwaggerGen(option =>
{
    ////JWT Config
    option.DescribeAllParametersInCamelCase();
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

Bước 19: Viết tiếp SurveyController (đối tượng chính), hoàn thành controller này theo những Service đã được viết trước đó trong project APIService:
namespace Psychological_APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // GET: api/<SurveyController>
        [HttpGet]
        public async Task<IEnumerable<Survey>> Get()
        {
            return await _surveyService.GetAll();
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]
        public async Task<Survey> GetById(int id)
        {
            return await _surveyService.GetById(id);
        }

        [HttpGet("(Name)/(Number)/(Verygood)")]
        [Authorize(Roles = "1,2")]
        public async Task<IEnumerable<Survey>> Search(string Name, int Number, int Verygood)
        {
            return await _surveyService.SearchAsync(Name, Number, Verygood);
        }

        // POST api/<SurveyController>
        [HttpPost]
        [Authorize(Roles = "1, 2")]
        public async Task<int> Post(Survey survey)
        {
            return await _surveyService.Create(survey);
        }

        // PUT api/<SurveyController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<int> Put(int id, [FromBody] Survey survey)
        {
            return await _surveyService.Update(survey);
        }

        // DELETE api/<SurveyController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<bool> Delete(int id)
        {
            return await _surveyService.Delete(id);
        }
    }
}


Bước 20: Tạo project mới tên là (Dự án).MVCWebApp và NuGet thư viện Microsoft.AspNetCore.Authentication.JwtBearer 8.0.1

Bước 21: Tạo controller AccountController trong controller của WebApp, giống tên với controller trong APIService và viết như sau (đây là bảng chính):
public class AccountController : Controller
{
	private string APIEndPoint = "https://localhost:7097/api/";   =>>>Sửa cho đúng port của API
	public IActionResult Index()
	{
		return RedirectToAction("Login");
	}

	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginRequest login)
	{

		try
		{
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "SurveyUserAccounts/Login", login))   =>> Viết đúng tên API
				{
					if (response.IsSuccessStatusCode)
					{
						var tokenString = await response.Content.ReadAsStringAsync();

						var tokenHandler = new JwtSecurityTokenHandler();
						var jwtToken = tokenHandler.ReadToken(tokenString) as JwtSecurityToken;

						if (jwtToken != null)
						{
							var userName = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
							var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

							var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, userName),
						new Claim(ClaimTypes.Role, role),
					};

							var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
							await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

							Response.Cookies.Append("UserName", userName);
							Response.Cookies.Append("Role", role);
							Response.Cookies.Append("TokenString", tokenString);

							return RedirectToAction("Index", "Home");
						}
					}
				}
			}
		}
		catch (Exception ex)
		{

		}

		HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		ModelState.AddModelError("", "Login failure");
		return View();
	}

	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		Response.Cookies.Delete("UserName");
		Response.Cookies.Delete("Role");
		Response.Cookies.Delete("TokenString");

		return RedirectToAction("Login", "Account");
	}

	public async Task<IActionResult> Forbidden()
	{
		return View();
	}
}

Bước 22: Tạo giao diện login và Forbidden
@model Psychological.MVCWebApp.Models.LoginRequest

@*
    For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
*@
@{
	Layout = null;
}
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>@ViewData["Title"] - Psychological.MVCWebApp</title>
	<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
	<link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
	<link rel="stylesheet" href="~/Psychological.MVCWebApp.styles.css" asp-append-version="true" />
</head>
<body>
	<header>
		<nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
			<div class="container-fluid">
				<a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">Psychological.MVCWebApp</a>
				<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
						aria-expanded="false" aria-label="Toggle navigation">
					<span class="navbar-toggler-icon"></span>
				</button>
				<div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
					<ul class="navbar-nav flex-grow-1">
						<li class="nav-item">
							<a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
						</li>
						<li class="nav-item">
							<a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
						</li>
					</ul>
				</div>
			</div>
		</nav>
	</header>
	<div class="container">
		<main role="main" class="pb-3">
			<div class="container">
				<main role="main" class="pb-3">
					<div class="row text-center">
						<h1 class="display-4">Login</h1>
					</div>
					<div class="row">
						<div class="col-md-4">
						</div>
						<div class="col-md-4">
							<form asp-action="Login">
								<div asp-validation-summary="ModelOnly" class="text-danger"></div>
								<div class="form-group">
									<label asp-for="UserName" class="control-label"></label>
									<input asp-for="UserName" class="form-control" />
									<span asp-validation-for="UserName" class="text-danger"></span>
								</div>
								<div class="form-group">
									<label asp-for="Password" class="control-label"></label>
									<input type="password" asp-for="Password" class="form-control" />
									<span asp-validation-for="Password" class="text-danger"></span>
								</div>
								<div class="form-group">
									<input type="submit" value="Login" class="btn btn-primary" />
								</div>
							</form>
						</div>
						<div class="col-md-4">
						</div>
					</div>
				</main>
			</div>
		</main>
	</div>
	<footer class="border-top footer text-muted">
		<div class="container">
			&copy; 2025 - Psychological.MVCWebApp - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
		</div>
	</footer>
	<script src="~/lib/jquery/dist/jquery.min.js"></script>
	<script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
	<script src="~/js/site.js" asp-append-version="true"></script>
</body>
</html>

============> VÀ <=============

@*
    For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
*@
@{
	Layout = null;
}
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>@ViewData["Title"] - Psychological.MVCWebApp</title>
	<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
	<link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
	<link rel="stylesheet" href="~/Psychological.MVCWebApp.styles.css" asp-append-version="true" />
</head>
<body>
	<header>
		<nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
			<div class="container-fluid">
				<a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">Psychological.MVCWebApp</a>
				<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
						aria-expanded="false" aria-label="Toggle navigation">
					<span class="navbar-toggler-icon"></span>
				</button>
				<div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
					<ul class="navbar-nav flex-grow-1">
						<li class="nav-item">
							<a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
						</li>
						<li class="nav-item">
							<a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
						</li>
					</ul>
				</div>
			</div>
		</nav>
	</header>
	<div class="container">
		<main role="main" class="pb-3">
			<div class="row text-center">
				<h3 class="text-danger">Forbidden</h3>
				<h4 class="text-danger">You do not have permission to do this function!</h4>
				<div>
					<a asp-action="Login" asp-asp-controller="Account" class="btn btn-primary">Login</a>
				</div>
			</div>
		</main>
	</div>

	<footer class="border-top footer text-muted">
		<div class="container">
			&copy; 2025 - Psychological.MVCWebApp - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
		</div>
	</footer>
	<script src="~/lib/jquery/dist/jquery.min.js"></script>
	<script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
	<script src="~/js/site.js" asp-append-version="true"></script>
</body>
</html>


Bước 23: Thêm phần sau vào dưới <ul></ul> của _Layout.cshtml của Shared trong WebApp
<div class="nav-item text-nowrap">
    Welcome
    <strong>@(Context.Request.Cookies["UserName"]?.ToString() ?? "Guest")</strong>
    |
    <a asp-controller="Account" asp-action="Logout">Logout</a>
</div>



Bước 25: Thêm phần sau vào program.cs của WebApp trước var app = builder.Build();
builder.Services.AddAuthentication()
	.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
	{
		options.LoginPath = new PathString("/Account/Login");
		options.AccessDeniedPath = new PathString("/Account/Forbiden");
		options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

	});




Bước 26: Thêm phần sau trên tên class của home controller:
[Authorize]

Bước 27: Viết loginrequest trong models của WebApp:
public class LoginRequest
{
	public string UserName { get; set; }
	public string Password { get; set; }
}


Bước 28: Cho WebApp dependenci đến Project Repository để gencode cho nhanh.
Bước 29: Sau đó chọn folder controller của WebApp -> Chọn new controller -> chọn kiểu using Entity Frameword để tạo Controller -> Sau đó comment toàn bộ phần bên trong class controller

Bước 30: Viết lại Index() của survey controller của webapp:

private string APIEndPoint = "https://localhost:7097/api/";
public SurveysController() { }

public async Task<IActionResult> Index()
{
    using (var httpClient = new HttpClient())
    {
        #region Add Token to header of Request

        var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

        #endregion


        using (var response = await httpClient.GetAsync(APIEndPoint + "Survey"))
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Survey>>(content);

                if (result != null)
                {
                    return View(result);
                }
            }
        }
    }
    return View(new List<Survey>());
}


Bước 31: Viết thằng Delete trong survey controller:

 ========> Trong SurveyController(đối tượng chính) của webapp, viết Delete sau:   ==========================
	[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuicly(int id)
        {
            bool deleteStatus = false;
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.DeleteAsync(APIEndPoint + "Survey/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        deleteStatus = true;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

========> Trong Index.html của Surveys xóa thẻ delete cũ là thêm form delete mới:   ==========================

     -> Xóa:                 <a asp-action="Delete" asp-route-id="@item.Id">Delete</a> |
     -> Thêm:
<form method="post" asp-action="DeleteQuicly" asp-route-id="@item.Id" style="display:inline;">
    <button type="submit" class="btn btn-danger" onclick="return confirm('Are you sure you want to delete this item?');">
        <span class="fw-bold">X</span>
    </button>
</form>


Bước 32: Viết thằng details trong survey controller của WebApp:

 	public async Task<IActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient()) {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "Survey/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Survey>(content);

                        if(result != null) { return View(result); }
                    }
                    ModelState.AddModelError("", "Không thể tải dữ liệu. Vui lòng thử lại!");
                    return View("Error");
                }
            }
        }

Bước 33: Thêm thằng sau vào program.cs của API bên trên app.Run();:
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

Bước 34: Gen tiếp controller SurveyCategoryController (đối tượng phụ) bằng cách add controller của WebApp, chọn using EF Framework sau đó chọn đúng model và dbcontext

Bước 35: Viết API của SurveyCategory 2 API getall và getbyId:
=> Trong class SurveyCategoryService viết thêm class Interface:
	public interface ISurveyCategoryService
    {
        Task<List<ServeyCategory>> GetAll();
        Task<ServeyCategory> GetById(int id);
    }

=> Viết class SurveyCategoryService sau:
public class SurveyCategoryService : ISurveyCategoryService
{
    private SurveyCategoryRepository _surveyCategoryRepository;

    public SurveyCategoryService ()
    {
        _surveyCategoryRepository = new SurveyCategoryRepository();
    }

    public async Task<List<ServeyCategory>> GetAll()
    {
        return await _surveyCategoryRepository.GetAllAsync();
    }

    public async Task<ServeyCategory> GetById(int id)
    {
        return await _surveyCategoryRepository.GetByIdAsync(id);
    }
}

=> Thêm DI vào programcs của API

Bước 36: Viết SurveyCategoryController trong API chỉ cần viết rõ Get và GetById cách tạo giống bước 13:

[Route("api/[controller]")]
[ApiController]
public class ServeyCategoriesController : ControllerBase
{
    private readonly ISurveyCategoryService _surveyCategoryService;
    public ServeyCategoriesController(ISurveyCategoryService surveyCategoryService)
    {
        _surveyCategoryService = surveyCategoryService;
    }

    // GET: api/<ServeyCategoriesController>
    [HttpGet]
    public async Task<IEnumerable<ServeyCategory>> Get()
    {
        return await _surveyCategoryService.GetAll();
    }

    // GET api/<ServeyCategoriesController>/5
    [HttpGet("{id}")]
    [Authorize(Roles = "1,2")]
    public async Task<ServeyCategory> GetById(int id)
    {
        return await _surveyCategoryService.GetById(id);
    }

    // POST api/<ServeyCategoriesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ServeyCategoriesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ServeyCategoriesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

Bước 37: Quay lại SurveyController để viết tiếp edit post, edit get và hàm get đối tượng phụ:
	// GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var surveysCategory = new List<ServeyCategory>();
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "ServeyCategories")) => Đối tượng phụ
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        surveysCategory = JsonConvert.DeserializeObject<List<ServeyCategory>>(content);
                    }
                }
            }
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "Survey/" + id)) => Đối tượng chính
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Survey>(content);
                        if (result != null)
                        {
                            ViewData["CategoryId"] = new SelectList(surveysCategory, "Id", "Name", result.CategoryId); => Id và Name là field của đối tượng phụ
                            return View(result);
                        }
                    }
                   
                }
            }
            if (surveysCategory == null)
            {
                surveysCategory = new List<ServeyCategory>(); // Khởi tạo danh sách trống để tránh lỗi
            }
            ViewData["CategoryId"] = new SelectList(surveysCategory, "Id", "Name");
            return View(new Survey());
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Survey survey)
        {
            var saveStatus = false;
            if (survey == null)
            {
                // Xử lý nếu survey là null
                survey = new Survey();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                        using (var response = await httpClient.PutAsJsonAsync(APIEndPoint + "Survey/" + survey.Id, survey))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var content = await response.Content.ReadAsStringAsync();
                                var result = JsonConvert.DeserializeObject<int>(content);
                                if (result > 0)
                                {
                                    saveStatus = true;
                                }
                            }
                            else
                            {
                                // Xử lý khi request không thành công (in ra log hoặc lỗi)
                                var errorContent = await response.Content.ReadAsStringAsync();
                                // Log lỗi ở đây nếu cần
                            }
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            if (saveStatus)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (survey.CategoryId == null)
                {
                    // Xử lý nếu survey là null
                    survey = new Survey();
                }
                var categories = await this.GetServeyCategory();
                if (categories == null)
                {
                    // Xử lý trường hợp không có danh mục
                    categories = new List<ServeyCategory>();
                }
                ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", survey.CategoryId);
                return View(survey);
            }
        }

	//Get đối tượng phụ
        public async Task<List<ServeyCategory>> GetServeyCategory()
        {
            var serveyCategory = new List<ServeyCategory>();
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "ServeyCategories"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        serveyCategory = JsonConvert.DeserializeObject<List<ServeyCategory>>(content);
                    }
                }
            }
            return serveyCategory;
        }

Bước 38: Viết get và post create của webapp:

// GET: Surveys/Create
public async Task<IActionResult> Create()
{
    ViewData["CategoryId"] = new SelectList(await this.GetServeyCategory(), "Id", "Name");
    return View();
}

// POST: Surveys/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Survey survey)
{
    if (ModelState.IsValid)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "Survey/", survey))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<int>(content);

                        if (result > 0)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
    }
    ViewData["CategoryId"] = new SelectList(await this.GetServeyCategory(), "Id", "Name", survey.CategoryId);

    return View(survey);
}

4 bước để làm odata:
3 bước trong zalo và ENABELQUERY TRONG API => 8-10 điểm

