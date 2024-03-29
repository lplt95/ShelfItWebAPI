﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using DataRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ShelfItService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetMaxIDNumber();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void SetMaxIDNumber()
        {
            var bookMax = BookRepository.ksiazki.Max(x => x.idPozycja);
            var filmMax = FilmRepository.filmy.Max(x => x.idPozycja);
            var musicMax = MusicRepository.muzyka.Max(x => x.idPozycja);
            List<int> maxList = new List<int>() { bookMax, filmMax, musicMax };
            Repository.maxPosID = maxList.Max(x => x);
        }
    }
}
