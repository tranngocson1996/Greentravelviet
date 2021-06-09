using System.Collections.Generic;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class DocumentProvider : DataAccess
    {
        public abstract bool InsertDocument(DocumentEntity entity);
        public abstract bool UpdateDocument(DocumentEntity entity);
        public abstract bool DeleteDocument(int _DocumentID);
        public abstract DocumentEntity GetDocumentByID(int _DocumentID);
        public abstract List<DocumentEntity> GetAllDocuments();

        public abstract List<DocumentEntity> GetDocumentByDocumentTypeID(int _DocumentTypeID);
    }
}