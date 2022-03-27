using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                string message = GetMessageForModel(userId, description);
            }
            catch (Exception ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }

            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);

            try
            {
                int result = _taskService.AddTaskForUser(userId, task);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("Invalid userId", ex);
            }

            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("User not found", ex);
            }

            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("The task already exists", ex);
            }

            return null;
        }
    }
}