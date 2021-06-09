using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BIC.Entity;
using BIC.Utils;

namespace BIC.DAO
{
    public class DocumentDAO : DocumentProvider
    {
        #region Stored Procedure names

        private const string INSERT_DOCUMENT = "[dbo].DocumentInsert";
        private const string UPDATE_DOCUMENT = "[dbo].DocumentUpdate";
        private const string DELETE_DOCUMENT = "[dbo].DocumentDelete";
        private const string SELECT_DOCUMENT_BYID = "[dbo].DocumentGetByID";
        private const string SELECT_ALL_DOCUMENT = "[dbo].DocumentsGetAll";
        private const string SELECT_DOCUMENT_BY_DOCUMENTTYPEID = "[dbo].DocumentsGetByDocumentTypeID";

        #endregion Stored Procedure names

        /// <summary>
        /// Create a new DocumentEntity
        /// </summary>
        public override bool InsertDocument(DocumentEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_DOCUMENT, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BriefDescription", SqlDbType.NVarChar).Value = entity.BriefDescription;
                cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = entity.DisplayName;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
                cmd.Parameters.Add("@Size", SqlDbType.Int).Value = entity.Size;
                cmd.Parameters.Add("@Ext", SqlDbType.NVarChar).Value = entity.Ext;
                cmd.Parameters.Add("@DocumentTypeID", SqlDbType.Int).Value = entity.DocumentTypeID;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = entity.CreatedDate;
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = entity.ModifiedDate;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = entity.CreatedBy;
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = entity.ModifiedBy;
                cmd.Parameters.Add("@ViewNo", SqlDbType.Int).Value = entity.ViewNo;
                cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = entity.IsNew;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@DocumentNo", SqlDbType.NVarChar).Value = entity.DocumentNo;
                cmd.Parameters.Add("@UserNameView", SqlDbType.NVarChar).Value = entity.UserNameView;
                cmd.Parameters.Add("@UserNameEdit", SqlDbType.NVarChar).Value = entity.UserNameEdit;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@DocumentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                entity.DocumentID = (Int32)cmd.Parameters["@DocumentID"].Value;
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Update a DocumentEntity
        /// </summary>
        public override bool UpdateDocument(DocumentEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_DOCUMENT, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DocumentID", SqlDbType.Int).Value = entity.DocumentID;
                cmd.Parameters.Add("@BriefDescription", SqlDbType.NVarChar).Value = entity.BriefDescription;
                cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = entity.DisplayName;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
                cmd.Parameters.Add("@Size", SqlDbType.Int).Value = entity.Size;
                cmd.Parameters.Add("@Ext", SqlDbType.NVarChar).Value = entity.Ext;
                cmd.Parameters.Add("@DocumentTypeID", SqlDbType.Int).Value = entity.DocumentTypeID;
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = entity.ModifiedDate;
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = entity.ModifiedBy;
                cmd.Parameters.Add("@ViewNo", SqlDbType.Int).Value = entity.ViewNo;
                cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = entity.IsNew;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@DocumentNo", SqlDbType.NVarChar).Value = entity.DocumentNo;
                cmd.Parameters.Add("@UserNameView", SqlDbType.NVarChar).Value = entity.UserNameView;
                cmd.Parameters.Add("@UserNameEdit", SqlDbType.NVarChar).Value = entity.UserNameEdit;
                cmd.Parameters.Add("@Priority", SqlDbType.NVarChar).Value = entity.Priority;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Deletes a DocumentEntity
        /// </summary>
        public override bool DeleteDocument(int _DocumentID)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_DOCUMENT, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DocumentID", SqlDbType.Int).Value = _DocumentID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Returns an existing Document with the specified ID
        /// </summary>
        public override DocumentEntity GetDocumentByID(int _DocumentID)
        {
            DocumentEntity _DocumentEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_DOCUMENT_BYID, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DocumentID", SqlDbType.Int).Value = _DocumentID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _DocumentEntity = GetDocumentFromReader(reader);
                }
                cn.Close();
            }
            return _DocumentEntity;
        }

        /// <summary>
        /// Returns a new DocumentEntity instance filled with the DataReader's current record data
        /// </summary>
        private DocumentEntity GetDocumentFromReader(IDataReader reader)
        {
            return new DocumentEntity(
                BicConvert.ToInt32(reader["DocumentID"]),
                reader["BriefDescription"].ToString().Trim(),
                reader["DisplayName"].ToString().Trim(),
                reader["Name"].ToString().Trim(),
                BicConvert.ToInt32(reader["Size"]),
                reader["Ext"].ToString().Trim(),
                BicConvert.ToInt32(reader["DocumentTypeID"]),
                BicConvert.ToDateTime(reader["CreatedDate"]),
                BicConvert.ToDateTime(reader["ModifiedDate"]),
                reader["CreatedBy"].ToString().Trim(),
                reader["ModifiedBy"].ToString().Trim(),
                BicConvert.ToInt32(reader["ViewNo"]),
                BicConvert.ToBoolean(reader["IsNew"]),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]),
                reader["DocumentNo"].ToString().Trim(),
                reader["UserNameView"].ToString().Trim(),
                reader["UserNameEdit"].ToString().Trim());
        }

        /// <summary>
        /// Returns a collection with all the Documents
        /// </summary>
        public override List<DocumentEntity> GetAllDocuments()
        {
            List<DocumentEntity> _DocumentEntity = null;
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_DOCUMENT, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                _DocumentEntity = GetDocumentCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _DocumentEntity;
        }

        /// <summary>
        /// Returns a collection of DocumentEntity objects with the data read from the input DataReader
        /// </summary>
        private List<DocumentEntity> GetDocumentCollectionFromReader(IDataReader reader)
        {
            var documentEntity = new List<DocumentEntity>();
            while (reader.Read())
                documentEntity.Add(GetDocumentFromReader(reader));
            return documentEntity;
        }

        /// <summary>
        /// Returns the number of Documents for the specified DocumentTypeID
        /// </summary>
        public override List<DocumentEntity> GetDocumentByDocumentTypeID(int _DocumentTypeID)
        {
            List<DocumentEntity> _DocumentEntity = null;
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_DOCUMENT_BY_DOCUMENTTYPEID, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DocumentTypeID", SqlDbType.Int).Value = _DocumentTypeID;
                cn.Open();
                _DocumentEntity = GetDocumentCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _DocumentEntity;
        }
    }
}