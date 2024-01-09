using VacIT.Cruds;

namespace VacIT.Models
{
    public class VacITPageModel
    {
        private CandidateApplicationCrud _candidateApplicationCrud;

        public VacITPageModel(CandidateApplicationCrud candidateApplicationCrud)
        {
            _candidateApplicationCrud = candidateApplicationCrud;
        }
    }
}
