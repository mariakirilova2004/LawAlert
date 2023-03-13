using LawAlert.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Infrastructure.Configurations
{
    public class InterestConfiguration : IEntityTypeConfiguration<Interest>
    {
            public void Configure(EntityTypeBuilder<Interest> builder)
            {
                builder.HasData(CreateInterests());
            }

            private List<Interest> CreateInterests()
            {
                var interests = new List<Interest>();

                var interest1 = new Interest()
                {
                    Id = 1,
                    Type = "Електронна търговия",
                    Description = "Електронната търговия се състои в купуването и продаването на продукти и услуги чрез електронни системи като Интернет."

                };

                interests.Add(interest1);

                var interest2 = new Interest()
                {
                    Id = 2,
                    Type = "Авторско право",
                    Description = "Авторското право представлява система от правни норми, уреждащи, регулиращи и защитаващи отношенията, възникнали при или по повод създаването и използването на научни, литературни, художествени и други произведения продукт на интелектуален труд."
                };

                interests.Add(interest2);

                var interest3 = new Interest()
                {
                    Id = 3,
                    Type = "Защита на лични данни",
                    Description = "Информационната поверителност е връзката между събирането и разпространението на данни, технологията, обществените очаквания за поверителност, контекстуалните информационни норми и правните и политически въпроси около тях."
                };

                interests.Add(interest3);

                var interest4 = new Interest()
                {
                    Id = 4,
                    Type = "Защита на конкуренцията",
                    Description = "Законът за защита на конкуренцията има за цел да осигури защита и условия за разширяване на конкуренцията и на свободната инициатива в стопанската дейност."
                };

                interests.Add(interest4);

                return interests;
            }
    }
}
