using System.Collections.Generic;


namespace Task_lesson6
{
    class Staff
    {

        private Dictionary<int, Emoloyee> _emoloyees;

        private Dictionary<int, Post> _posts;

        private ILogger _logger;

        public ILogger Logger
        {
            set 
            {
                _logger = value;
                foreach (var p in _posts)
                {
                    p.Value.Logger = value;
                }
            }
        }

        public Staff()
        {
            _emoloyees = new Dictionary<int, Emoloyee>();
            _posts = new Dictionary<int, Post>();
        }

        public bool AddEmployee(int employeeId, string name, string surname)
        {
            if (_emoloyees.ContainsKey(employeeId))
            {
                Log($"Staff::AddEmployee: Ошибка: сотрудник с id = {employeeId} уже существует.");
                return false;
            }
            else
            {
                _emoloyees.Add(employeeId,  new Emoloyee(employeeId, name, surname));
                return true;
            }

        }

        //   сначала хотел так сделать этот метод, но не получилось
        //
        //public bool AddPost<T>(int postId, string name) where T : Post
        //{
        //    if (_posts.ContainsKey(postId))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        _posts.Add(postId, new T(postId, name));
        //        return true;
        //    }
        //}

        public bool AddPost(PostType type, int postId, string name)
        {
            if (_posts.ContainsKey(postId))
            {
                Log($"Staff::AddPost: Ошибка: должность с id = {postId} уже существует.");
                return false;
            }
            else
            {
                Post post = null;
                switch (type)
                {
                    case PostType.Director:
                        post = new Director(postId, name);
                        break;
                    case PostType.DepartamentChief:
                        post = new DepartamentChief(postId, name);
                        break;
                    case PostType.Worker:
                        post = new Worker(postId, name);
                        break;
                    default:
                        break;
                }

                if (post != null)
                {
                    post.Logger = _logger;
                    _posts.Add(postId, post);
                    return true;
                }
                else
                {
                    Log($"Staff::AddPost: Ошибка: не удалось создать должность с id = {postId}.");
                    return false;
                }
            }
        }

        public bool SetEmployeeToPost(int employeeId, int postId)
        {
            if (!_emoloyees.ContainsKey(employeeId))
            {
                Log($"Staff::SetEmployeeToPost: Ошибка: сотрудник с id = {employeeId} не найден.");
                return false;
            }
            if (!_posts.ContainsKey(postId))
            {
                Log($"Staff::SetEmployeeToPost: Ошибка: должность с id = {postId} не найдено.");
                return false;
            }

            Emoloyee emp = _emoloyees[employeeId];
            Post post = _posts[postId];

            if (emp.Post != null)
            {
                if ( !DismissEmployeeFromPost(emp, emp.Post))
                {
                    return false;
                }
            }

            emp.Post = post;
            post.Emoloyee = emp;
            return true;
        }

        public bool DismissEmployeeFromPost(int employeeId, int postId)
        {
            if (!_emoloyees.ContainsKey(employeeId))
            {
                Log($"Staff::DismissEmployeeFromPost: Ошибка: сотрудник с id = {employeeId} не найден.");
                return false;
            }
            if (!_posts.ContainsKey(postId))
            {
                Log($"Staff::DismissEmployeeFromPost: Ошибка: должность с id = {postId} не найдено.");
                return false;
            }
            Emoloyee emp = _emoloyees[employeeId];
            Post post = _posts[postId];

            return DismissEmployeeFromPost(emp, post);
        }

        private bool DismissEmployeeFromPost(Emoloyee emp, Post post)
        {
            emp.Post = null;
            post.Emoloyee = null;
            return true;
        }

        public bool SetInferrior(int chiefId, int inferriorId)
        {
            if (!_posts.ContainsKey(chiefId))
            {
                Log($"Staff::SetInferrior: Ошибка: должность с id = {chiefId} не найдено.");
                return false;
            }
            if (!_posts.ContainsKey(inferriorId))
            {
                Log($"Staff::SetInferrior: Ошибка: должность с id = {inferriorId} не найдено.");
                return false;
            }

            Post chief = _posts[chiefId];
            Post inferrior = _posts[inferriorId];
            return chief.AddInferior(inferrior);
        }

        private void Log(string message)
        {
            if (_logger != null)
            {
                _logger.Log(message);
            }
        }

    }
}
