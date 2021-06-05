using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Test
{
    [TestFixture]
    public class TaskControllerTest
    {
        [Test]
        public async Task ShouldReturnCorrectTaskById()
        {
            var options = new DbContextOptionsBuilder<TodoTaskContext>().UseInMemoryDatabase("TodoDB").Options;

            var task1 = new TodoTask
            {
                Description = "First Task",
                IsCompleted = true
            };

            using (var context = new TodoTaskContext(options))
            {
                // Arrange
                context.Add(task1);
                await context.SaveChangesAsync();

                TodoTaskRepository repository = new TodoTaskRepository(context);

                // Act
                var todoTaskById = await repository.GetTaskByIdAsync(1);

                // Assert
                Assert.That(todoTaskById.Description, Is.EqualTo(task1.Description));

            }
        }

        [Test]
        public async Task ShouldUpdateTask()
        {
            var options = new DbContextOptionsBuilder<TodoTaskContext>().UseInMemoryDatabase("TodoDB").Options;

            using (var context = new TodoTaskContext(options))
            {
                // Arrange
                TodoTaskRepository repository = new TodoTaskRepository(context);

                var task = await repository.GetTaskByIdAsync(1);
                task.IsCompleted = false;

                // Act
                var todoTaskById = await repository.PutTaskAsync(task);

                // Assert
                Assert.That(todoTaskById.IsCompleted, Is.EqualTo(task.IsCompleted));

            }
        }

        [Test]
        public async Task ShouldCreateTask()
        {
            var options = new DbContextOptionsBuilder<TodoTaskContext>().UseInMemoryDatabase("CreateTaskDB").Options;

            using (var context = new TodoTaskContext(options))
            {
                // Arrange
                var task = new TodoTask
                {
                    Description = "New Task Created",
                    IsCompleted = false
                };

                TodoTaskRepository repository = new TodoTaskRepository(context);

                // Act
                var newTaskCreated = await repository.PostTaskAsync(task);

                // Assert
                Assert.That(newTaskCreated.Description, Is.EqualTo(task.Description));

            }
        }

        [Test]
        public async Task ShouldReturnListOfTasks()
        {
            var options = new DbContextOptionsBuilder<TodoTaskContext>().UseInMemoryDatabase("ListOfTaskDB").Options;

            var task1 = new TodoTask
            {
                Description = "First Task",
                IsCompleted = true
            };

            var task2 = new TodoTask
            {
                Description = "Second Task",
                IsCompleted = false
            };

            using (var context = new TodoTaskContext(options))
            {
                // Arrange
                context.Add(task1);
                context.Add(task2);
                await context.SaveChangesAsync();

                TodoTaskRepository repository = new TodoTaskRepository(context);

                // Act
                var todoList = await repository.GetAllTasksAsync();

                // Assert
                Assert.That(todoList, Is.EqualTo(new List<TodoTask> { task1, task2 }));

            }
        }
    }
}