using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsRegionalHeadDetail
    {
        public int Id { get; set; }
        public int? RegionalHeadId { get; set; }
        public int? CandidateId { get; set; }
        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public int? InterviewRecommendationId { get; set; }
        public int? VacancyId { get; set; }
        public int? OfferLetterId { get; set; }

        public virtual TrnsInterviewRecommendation InterviewRecommendation { get; set; }
        public virtual TrnsOfferLetter OfferLetter { get; set; }
        public virtual TrnsRegionalHead RegionalHead { get; set; }
        public virtual TrnsVacancyRequest Vacancy { get; set; }
    }
}
