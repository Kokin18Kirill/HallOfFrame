using HallOfFame.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HallOfFame.Controllers
{
    /// <summary>
    /// Сонтроллер для сотрудников
    /// </summary>
    [Route("api/v1/")]
    [ApiController]
    public class PersonController : Controller
    {
        /// <summary>
        /// Получение всех сотрудников
        /// </summary>
        [HttpGet("persons/")]
        public async Task<ActionResult> GetPersons()
        {
            try
            {
                var persons = await ModelContext.GetContext().Person.ToListAsync();
                if (persons == null)
                {
                    return NotFound("Сотрудников нет");
                }
                return Ok(persons);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    e.ToString());
            }
        }

        /// <summary>
        /// Получение определенного сотрудника по id
        /// </summary>
        [HttpGet("persons/{id}")]
        public async Task<ActionResult> GetPerson(long id)
        {
            try
            {
                var person = await ModelContext.GetContext().Person.FirstOrDefaultAsync(w => w.Id == id);
                if (person == null)
                {
                    return NotFound("Сотрудника с таким id нет");
                }
                return Ok(person);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    e.ToString());
            }
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        [HttpPost("person/")]
        public async Task<ActionResult> PostPerson(Person newPerson)
        {
            try
            {
                await ModelContext.GetContext().Person.AddAsync(newPerson);
                ModelContext.GetContext().UpdateRange(newPerson.Skills);
                await ModelContext.GetContext().SaveChangesAsync();

                return Ok(newPerson);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                     e.ToString());
            }
        }

        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        [HttpPut("person/{id}")]
        public async Task<ActionResult> PutPerson(long idOldPerson, Person newPerson)
        {
            try
            {
                var oldPerson = ModelContext.GetContext().Person.FirstOrDefaultAsync(w => w.Id == idOldPerson);
                if (oldPerson == null)
                {
                    return BadRequest("Пользователя с таким id нет.");
                }

                ModelContext.GetContext().Person.Update(newPerson);
                ModelContext.GetContext().Skill.UpdateRange(newPerson.Skills);

                await ModelContext.GetContext().SaveChangesAsync();
                return Ok(newPerson);

            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    e.ToString());
            }
        }

        /// <summary>
        /// Удаление сотрудника по id
        /// </summary>
        [HttpDelete("person/{id}")]
        public async Task<ActionResult> DeletePerson(long id)
        {
            try
            {
                var person = await ModelContext.GetContext().Person.FirstOrDefaultAsync(w => w.Id == id);
                if (person == null)
                {
                    return BadRequest("Пользователя с таким id нет.");
                }
                ModelContext.GetContext().Person.Remove(person);
                ModelContext.GetContext().Skill.RemoveRange(person.Skills);
                await ModelContext.GetContext().SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    e.ToString());
            }
        }
    }
}
