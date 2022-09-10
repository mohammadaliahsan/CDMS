SELECT PF.Id, PF.CreatedBy, CB.NormalizedUserName AS CreatedByName, PF.CreatedDate, PF.ProposalNo, PF.ProposalId, PF.Remarks,
PF.Description, PF.AssignedTo, ATo.NormalizedUserName AS AssignedToName,
    PF.UpdatedBy,
    PF.UpdatedDate,
    PF.CompanyId,
    PF.BranchId
FROM proposalfeedback PF 
INNER JOIN proposal P ON PF.ProposalId = P.Id
LEFT JOIN users CB ON PF.CreatedBy = CB.Id
LEFT JOIN users ATo ON PF.AssignedTo = Ato.Id;
