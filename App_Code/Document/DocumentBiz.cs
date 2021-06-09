using System;
using System.Collections.Generic;
using BIC.DAO;
using BIC.Entity;

namespace BIC.Biz
{
    public class DocumentBiz : BaseDocument
    {
        /// <summary>
        /// Create a new Document
        /// </summary>
        public static bool InsertDocument(DocumentEntity documentEntity)
        {
            documentEntity.CreatedDate = DateTime.Now;
            documentEntity.ModifiedDate = DateTime.Now;
            documentEntity.CreatedBy = CurrentUserName;
            documentEntity.ModifiedBy = CurrentUserName;
            var documentDA0 = new DocumentDAO();
            bool ret = documentDA0.InsertDocument(documentEntity);
            PurgeCacheItems("Document_Document");
            return ret;
        }

        /// <summary>
        /// Update a DocumentEntity
        /// </summary>
        public static bool UpdateDocument(DocumentEntity documentEntity)
        {
            documentEntity.ModifiedDate = DateTime.Now;
            documentEntity.ModifiedBy = CurrentUserName;
            var documentDA0 = new DocumentDAO();
            bool ret = documentDA0.UpdateDocument(documentEntity);
            PurgeCacheItems("Document_Document_" + documentEntity.DocumentID);
            PurgeCacheItems("Document_Document");
            return ret;
        }

        /// <summary>
        /// Delete a DocumentEntity
        /// </summary>
        public static bool DeleteDocument(int _DocumentID)
        {
            var documentDA0 = new DocumentDAO();
            bool ret = documentDA0.DeleteDocument(_DocumentID);
            PurgeCacheItems("Document_Document");
            return ret;
        }

        /// <summary>
        /// Returns an existing Document with the specified ID
        /// </summary>
        public static DocumentEntity GetDocumentByID(int _DocumentID)
        {
            DocumentEntity documentEntity = null;
            string key = "Document_Document_" + _DocumentID;
            if (Cache[key] != null)
            {
                documentEntity = (DocumentEntity) Cache[key];
            }
            else
            {
                var documentDA0 = new DocumentDAO();
                documentEntity = documentDA0.GetDocumentByID(_DocumentID);
                CacheData(key, documentEntity);
            }
            return documentEntity;
        }

        /// <summary>
        /// Returns a collection with all the Documents
        /// </summary>
        public static List<DocumentEntity> GetAllDocuments()
        {
            List<DocumentEntity> DocumentsEntity = null;
            string key = "Document_Document";

            if (Cache[key] != null)
            {
                DocumentsEntity = (List<DocumentEntity>) Cache[key];
            }
            else
            {
                var documentDA0 = new DocumentDAO();
                DocumentsEntity = documentDA0.GetAllDocuments();
                CacheData(key, DocumentsEntity);
            }
            return DocumentsEntity;
        }

        /// <summary>
        /// Returns the number of Documents for the specified DocumentTypeID
        /// </summary>
        public static List<DocumentEntity> GetDocumentByDocumentTypeID(int _DocumentTypeID)
        {
            List<DocumentEntity> documentsEntity = null;
            var documentDAO = new DocumentDAO();
            documentsEntity = documentDAO.GetDocumentByDocumentTypeID(_DocumentTypeID);
            return documentsEntity;
        }
    }
}