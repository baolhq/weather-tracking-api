using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WeatherTrackingApi.Models;

namespace WeatherTrackingApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WeatherTrackingDbContext context)
        {
            context.Database.EnsureCreated();

            InitializeAccounts(context);
            InitializeCities(context);
            InitializeWeatherStatus(context);
        }

        private static void InitializeAccounts(WeatherTrackingDbContext context)
        {
            if (context.Accounts.Any()) return;

            var accounts = new Account[]
            {
                new()
                {
                    Username = "admin", Password = Utils.ComputeSha256Hash("123123"), FullName = "Admin",
                    Email = "admin@gmail.com",
                    IsEmailValidated = true,
                    Address = "Ho Chi Minh", Avatar = null, DateOfBirth = DateTime.Parse("1996-03-26"),
                    LastLogin = DateTime.Now - TimeSpan.FromDays(1),
                    IsActive = true, IsAdmin = true
                },
                new()
                {
                    Username = "anv", Password = Utils.ComputeSha256Hash("123456"), FullName = "Nguyen Van A",
                    Email = "anv@gmail.com",
                    IsEmailValidated = true,
                    Address = "Can Tho", Avatar = null, DateOfBirth = DateTime.Parse("2001-02-23"),
                    LastLogin = DateTime.Now,
                    IsActive = true, IsAdmin = false
                },
                new()
                {
                    Username = "btv", Password = Utils.ComputeSha256Hash("321321"), FullName = "Tran Van B",
                    Email = "btv@gmail.com",
                    IsEmailValidated = false,
                    Address = "Soc Trang", Avatar = null, DateOfBirth = DateTime.Parse("2005-04-23"),
                    LastLogin = DateTime.Now,
                    IsActive = true, IsAdmin = false
                },
                new()
                {
                    Username = "clt", Password = Utils.ComputeSha256Hash("232323"), FullName = "Le Thi C",
                    Email = "clt@gmail.com",
                    IsEmailValidated = true,
                    Address = "Dong Thap", Avatar = null, DateOfBirth = DateTime.Parse("2003-04-13"),
                    LastLogin = DateTime.Now - TimeSpan.FromDays(100),
                    IsActive = false, IsAdmin = false
                },
            };

            foreach (var account in accounts) context.Accounts.Add(account);
            context.SaveChanges();
        }

        private static void InitializeCities(WeatherTrackingDbContext context)
        {
            if (context.Cities.Any()) return;

            var cities = new City[]
            {
                new()
                {
                    CityName = "Can Tho", TimeZone = 7,
                    Longitude = (float)10.013465, Latitude = (float)105.732262
                },
                new()
                {
                    CityName = "Ho Chi Minh", TimeZone = 7,
                    Longitude = (float)10.75, Latitude = (float)106.6667
                },
                new()
                {
                    CityName = "Ca Mau", TimeZone = 7,
                    Longitude = (float)9.1769, Latitude = (float)105.15
                },
                new()
                {
                    CityName = "Vung Tau", TimeZone = 7,
                    Longitude = (float)10.346, Latitude = (float)107.0843
                }
            };

            foreach (var city in cities) context.Cities.Add(city);
            context.SaveChanges();
        }

        private static void InitializeWeatherStatus(WeatherTrackingDbContext context)
        {
            if (context.WeatherStatus.Any()) return;

            var weatherStatus = new WeatherStatus[]
            {
                new()
                {
                    CityId = 1, WeatherName = "Light rain", WeatherImage = null,
                    Description = "Feels like 37°C. Light rain. Light breeze",
                    TimeStartInSec = 1657007434, TimeEndInSec = 1656985834,
                    LastUpdated = DateTime.Now, Humidity = 79, TemperatureInC = 30,
                    WindSpeed = (float)2.6, Pressure = 1005, UvSunIndex = 5
                },
                new()
                {
                    CityId = 2, WeatherName = "Scattered clouds", WeatherImage = null,
                    Description = "Feels like 38°C. Scattered clouds. Gentle Breeze",
                    TimeStartInSec = 1657007434, TimeEndInSec = 1656985834,
                    LastUpdated = DateTime.Now, Humidity = 79, TemperatureInC = 31,
                    WindSpeed = (float)5.1, Pressure = 1005, UvSunIndex = 5
                },
                new()
                {
                    CityId = 3, WeatherName = "Scattered clouds", WeatherImage = null,
                    Description = "Feels like 36°C. Scattered clouds. Moderate breeze",
                    TimeStartInSec = 1657007434, TimeEndInSec = 1656985834,
                    LastUpdated = DateTime.Now, Humidity = 57, TemperatureInC = 32,
                    WindSpeed = (float)6.3, Pressure = 1006, UvSunIndex = 5
                },
                new()
                {
                    CityId = 4, WeatherName = "Broken clouds", WeatherImage = null,
                    Description = "Feels like 35°C. Broken clouds. Moderate breeze",
                    TimeStartInSec = 1657007434, TimeEndInSec = 1656985834,
                    LastUpdated = DateTime.Now, Humidity = 73, TemperatureInC = 30,
                    WindSpeed = (float)6.3, Pressure = 1006, UvSunIndex = 5
                },
            };

            foreach (var status in weatherStatus) context.WeatherStatus.Add(status);
            context.SaveChanges();
        }

        
    }
}