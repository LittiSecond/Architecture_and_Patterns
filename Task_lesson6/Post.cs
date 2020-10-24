using System.Collections.Generic;


namespace Task_lesson6
{
    abstract class Post : IPost
    {
        protected List<Post> _inferiors;
        private ILogger _logger;

        public string Name { get; private set; }

        public Emoloyee Emoloyee {get; set;}

        public Post Chiff { get; set; }

        public int Id { get; private set; }

        public ILogger Logger
        {
            set
            {
                _logger = value;
            }

        }

        public Post(int id, string name)
        {
            _inferiors = new List<Post>();
            Name = name;
            Id = id;
        }

        public virtual bool AddInferior(Post newInferior)
        {
            if (newInferior == null)
            {
                Log("Post::AddInferior: argument Exception");
                return false;
            }
            if (!_inferiors.Contains(newInferior))
            {
                if (newInferior.Chiff == null)
                {
                    _inferiors.Add(newInferior);
                    newInferior.Chiff = this;
                    return true;
                }
                else
                {
                    Log("Post::AddInferior: Ошибка: подчинённый уже имеет начальника");
                    return false;
                }
            }
            else
            {
                Log("Post::AddInferior: Ошибка: повторное назначение подчинённого");
                return false;
            }
        }

        public abstract bool WorkRequest(Request request);

        protected void Log(string message)
        {
            if (_logger != null)
            {
                _logger.Log(message);
            }
        }

    }
}
