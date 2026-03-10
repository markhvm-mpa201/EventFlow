using EventFlow.Business.Dtos;
using EventFlow.Business.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.MVC.Controllers;

public class AccountController(IHttpClientFactory _httpClientFactory) : Controller
{
    private readonly HttpClient _httpClient = _httpClientFactory.CreateClient("ApiClient");

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);


        var response = await _httpClient.PostAsJsonAsync("https://localhost:44342/api/Auth/Login", dto);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "Something was wrong");
            return View(dto);
        }


        var tokenResult = await response.Content.ReadFromJsonAsync<ResultDto<AccessTokenDto>>() ?? new();


        Response.Cookies.Append("AccessToken", tokenResult.Data!.Token, new CookieOptions
        {
            HttpOnly = true,
            Expires = tokenResult.Data!.ExpiredDate
        });
        Response.Cookies.Append("RefreshToken", tokenResult.Data!.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Expires = tokenResult.Data!.RefreshTokenExpiredDate
        });


        return RedirectToAction("Index", "Home");

    }


    public async Task<IActionResult> Test()
    {

        var response = await _httpClient.GetAsync("https://localhost:44342/api/Products");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ResultDto<List<EventGetDto>>>();

            return Json(result);
        }
        return BadRequest();
    }
}
