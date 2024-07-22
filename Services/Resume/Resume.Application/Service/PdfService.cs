using SelectPdf;
using Resume.Application.DTOs;

namespace Resume.Application.Service
{
    public class PdfService
    {
        public static byte[] GeneratePdf(ResumeDto resumeDto)
        {
            var htmlContent = GenerateHtmlContent(resumeDto);

            // Create a new PDF document
            var pdfDocument = new HtmlToPdf();

            // Convert HTML to PDF
            PdfDocument pdf = pdfDocument.ConvertHtmlString(htmlContent);

            // Save the PDF to a MemoryStream
            using (var memoryStream = new MemoryStream())
            {
                pdf.Save(memoryStream);
                pdf.Close();

                return memoryStream.ToArray();
            }
        }

        private static string GenerateHtmlContent(ResumeDto resumeDto)
        {
            var experiencesHtml = GenerateHtmlList(resumeDto.Experiences, e =>
                $"<div class=\"section__list-item\">" +
                $"<div class=\"left\">" +
                $"<div class=\"name\">{e.CompanyName}</div>" +
                $"<div class=\"addr\">{e.Address}</div>" +
                $"<div class=\"duration\">{e.Duration}</div>" +
                $"</div>" +
                $"<div class=\"right\">" +
                $"<div class=\"name\">{e.Position}</div>" +
                $"<div class=\"desc\">{e.Description}</div>" +
                $"</div>" +
                $"</div>");

            var educationsHtml = GenerateHtmlList(resumeDto.Educations, e =>
                $"<div class=\"section__list-item\">" +
                $"<div class=\"left\">" +
                $"<div class=\"name\">{e.InstitutionName}</div>" +
                $"<div class=\"addr\">{e.Address}</div>" +
                $"<div class=\"duration\">{e.Duration}</div>" +
                $"</div>" +
                $"<div class=\"right\">" +
                $"<div class=\"name\">{e.Degree}</div>" +
                $"<div class=\"desc\">{e.Description}</div>" +
                $"</div>" +
                $"</div>");

            var projectsHtml = GenerateHtmlList(resumeDto.Projects, p =>
                $"<div class=\"section__list-item\">" +
                $"<div class=\"name\">{p.ProjectName}</div>" +
                $"<div class=\"text\">{p.Description}</div>" +
                $"</div>");

            var skillsHtml = GenerateHtmlList(resumeDto.Skills, s =>
                $"<div class=\"skills__item\">" +
                $"<div class=\"left\"><div class=\"name\">{s.SkillName}</div></div>" +
                $"<div class=\"right\">" +
                $"{GenerateSkillProficiency(s.ProficiencyLevel)}" +
                $"</div>" +
                $"</div>");

            var interestsHtml = string.Join(", ", resumeDto.Interests.Select(i => i.InterestName));

            return $@"
        <!DOCTYPE html>
        <html>
        <head>
            <link href='https://fonts.googleapis.com/css?family=Lato:400,300,700' rel='stylesheet' type='text/css'>
            <style>
                {GetCssStyles()}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <div class='full-name'>
                        <span class='first-name'>{resumeDto.FirstName}</span> 
                        <span class='last-name'>{resumeDto.LastName}</span>
                    </div>
                    <div class='contact-info'>
                        <span class='email'>Email: </span>
                        <span class='email-val'>{resumeDto.Email}</span>
                        <span class='separator'></span>
                        <span class='phone'>Phone: </span>
                        <span class='phone-val'>{resumeDto.Phone}</span>
                    </div>
                    <div class='about'>
                        <span class='position'>{resumeDto.Position}</span>
                        <span class='desc'>{resumeDto.Description}</span>
                    </div>
                </div>
                <div class='details'>
                    <div class='section'>
                        <div class='section__title'>Experience</div>
                        <div class='section__list'>
                            {experiencesHtml}
                        </div>
                    </div>
                    <div class='section'>
                        <div class='section__title'>Education</div>
                        <div class='section__list'>
                            {educationsHtml}
                        </div>
                    </div>
                    <div class='section'>
                        <div class='section__title'>Projects</div>
                        <div class='section__list'>
                            {projectsHtml}
                        </div>
                    </div>
                    <div class='section'>
                        <div class='section__title'>Skills</div>
                        <div class='skills'>
                            {skillsHtml}
                        </div>
                    </div>
                    <div class='section'>
                        <div class='section__title'>Interests</div>
                        <div class='section__list'>
                            <div class='section__list-item'>
                                {interestsHtml}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </body>
        </html>";
        }

        private static string GenerateHtmlList<T>(List<T> items, Func<T, string> itemToHtml)
        {
            if (items == null || !items.Any())
                return "<div class='section__list-item'>No items found.</div>";

            return string.Join("", items.Select(itemToHtml));
        }

        private static string GenerateSkillProficiency(int level)
        {
            var skillCheckboxes = string.Join("", Enumerable.Range(1, 5).Select(i =>
                $"<input id='ck{i}' type='checkbox' {(i <= level ? "checked" : "")}/><label for='ck{i}'></label>"));
            return skillCheckboxes;
        }

        private static string GetCssStyles()
        {
            return @"
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        html {
            height: 100%;  
        }
        body {
            min-height: 100%;  
            background: #eee;
            font-family: 'Lato', sans-serif;
            font-weight: 400;
            color: #222;
            font-size: 14px;
            line-height: 26px;
            padding-bottom: 50px;
        }
        .container {
            max-width: 700px;   
            background: #fff;
            margin: 0px auto 0px; 
            box-shadow: 1px 1px 2px #DAD7D7;
            border-radius: 3px;  
            padding: 40px;
            margin-top: 50px;
        }
        .header {
            margin-bottom: 30px;
        }
        .full-name {
            font-size: 40px;
            text-transform: uppercase;
            margin-bottom: 5px;
        }
        .first-name {
            font-weight: 700;
        }
        .last-name {
            font-weight: 300;
        }
        .contact-info {
            margin-bottom: 20px;
        }
        .email ,
        .phone {
            color: #999;
            font-weight: 300;
        } 
        .separator {
            height: 10px;
            display: inline-block;
            border-left: 2px solid #999;
            margin: 0px 10px;
        }
        .position {
            font-weight: bold;
            display: inline-block;
            margin-right: 10px;
            text-decoration: underline;
        }
        .details {
            line-height: 20px;
        }
        .section {
            margin-bottom: 40px;  
        }
        .section:last-of-type {
            margin-bottom: 0px;  
        }
        .section__title {
            letter-spacing: 2px;
            color: #54AFE4;
            font-weight: bold;
            margin-bottom: 10px;
            text-transform: uppercase;
        }
        .section__list-item {
            margin-bottom: 40px;
        }
        .section__list-item:last-of-type {
            margin-bottom: 0;
        }
        .left ,
        .right {
            vertical-align: top;
            display: inline-block;
        }
        .left {
            width: 60%;    
        }
        .right {
            text-align: right;
            width: 39%;    
        }
        .name {
            font-weight: bold;
        }
        a {
            text-decoration: none;
            color: #000;
            font-style: italic;
        }
        a:hover {
            text-decoration: underline;
            color: #000;
        }
        .skills {
        }
        .skills__item {
            margin-bottom: 10px;  
        }
        .skills__item .right {
            input {
                display: none;
            }
            label {
                display: inline-block;  
                width: 20px;
                height: 20px;
                background: #C3DEF3;
                border-radius: 20px;
                margin-right: 3px;
            }
            input:checked + label {
                background: #79A9CE;
            }
        }";
        }
    }

}
