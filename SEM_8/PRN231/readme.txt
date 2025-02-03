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

Bước 13: Tạo controller bằng cách => Chọn new scaffolded Item trong add của controller và viết controller như sau, tương tự với các controller khác:

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
