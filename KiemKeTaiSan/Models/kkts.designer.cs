﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KiemKeTaiSan.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="KiemKeTaiSan")]
	public partial class kktsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKhuVucPhong(KhuVucPhong instance);
    partial void UpdateKhuVucPhong(KhuVucPhong instance);
    partial void DeleteKhuVucPhong(KhuVucPhong instance);
    partial void InsertPhong(Phong instance);
    partial void UpdatePhong(Phong instance);
    partial void DeletePhong(Phong instance);
    partial void InsertLoaiPhong(LoaiPhong instance);
    partial void UpdateLoaiPhong(LoaiPhong instance);
    partial void DeleteLoaiPhong(LoaiPhong instance);
    #endregion
		
		public kktsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["KiemKeTaiSanConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public kktsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public kktsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public kktsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public kktsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<KhuVucPhong> KhuVucPhongs
		{
			get
			{
				return this.GetTable<KhuVucPhong>();
			}
		}
		
		public System.Data.Linq.Table<Phong> Phongs
		{
			get
			{
				return this.GetTable<Phong>();
			}
		}
		
		public System.Data.Linq.Table<LoaiPhong> LoaiPhongs
		{
			get
			{
				return this.GetTable<LoaiPhong>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KhuVucPhong")]
	public partial class KhuVucPhong : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaKV;
		
		private string _TenKV;
		
		private string _GhiChu;
		
		private System.Nullable<System.DateTime> _NgayCapNhat;
		
		private EntitySet<Phong> _Phongs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaKVChanging(int value);
    partial void OnMaKVChanged();
    partial void OnTenKVChanging(string value);
    partial void OnTenKVChanged();
    partial void OnGhiChuChanging(string value);
    partial void OnGhiChuChanged();
    partial void OnNgayCapNhatChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayCapNhatChanged();
    #endregion
		
		public KhuVucPhong()
		{
			this._Phongs = new EntitySet<Phong>(new Action<Phong>(this.attach_Phongs), new Action<Phong>(this.detach_Phongs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKV", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaKV
		{
			get
			{
				return this._MaKV;
			}
			set
			{
				if ((this._MaKV != value))
				{
					this.OnMaKVChanging(value);
					this.SendPropertyChanging();
					this._MaKV = value;
					this.SendPropertyChanged("MaKV");
					this.OnMaKVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenKV", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TenKV
		{
			get
			{
				return this._TenKV;
			}
			set
			{
				if ((this._TenKV != value))
				{
					this.OnTenKVChanging(value);
					this.SendPropertyChanging();
					this._TenKV = value;
					this.SendPropertyChanged("TenKV");
					this.OnTenKVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GhiChu", DbType="NVarChar(200)")]
		public string GhiChu
		{
			get
			{
				return this._GhiChu;
			}
			set
			{
				if ((this._GhiChu != value))
				{
					this.OnGhiChuChanging(value);
					this.SendPropertyChanging();
					this._GhiChu = value;
					this.SendPropertyChanged("GhiChu");
					this.OnGhiChuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayCapNhat
		{
			get
			{
				return this._NgayCapNhat;
			}
			set
			{
				if ((this._NgayCapNhat != value))
				{
					this.OnNgayCapNhatChanging(value);
					this.SendPropertyChanging();
					this._NgayCapNhat = value;
					this.SendPropertyChanged("NgayCapNhat");
					this.OnNgayCapNhatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhuVucPhong_Phong", Storage="_Phongs", ThisKey="MaKV", OtherKey="MaKV")]
		public EntitySet<Phong> Phongs
		{
			get
			{
				return this._Phongs;
			}
			set
			{
				this._Phongs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Phongs(Phong entity)
		{
			this.SendPropertyChanging();
			entity.KhuVucPhong = this;
		}
		
		private void detach_Phongs(Phong entity)
		{
			this.SendPropertyChanging();
			entity.KhuVucPhong = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Phong")]
	public partial class Phong : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaPhong;
		
		private int _MaLP;
		
		private int _MaKV;
		
		private string _TenPhong;
		
		private string _GhiChu;
		
		private System.DateTime _NgayCapNhat;
		
		private EntityRef<KhuVucPhong> _KhuVucPhong;
		
		private EntityRef<LoaiPhong> _LoaiPhong;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaPhongChanging(int value);
    partial void OnMaPhongChanged();
    partial void OnMaLPChanging(int value);
    partial void OnMaLPChanged();
    partial void OnMaKVChanging(int value);
    partial void OnMaKVChanged();
    partial void OnTenPhongChanging(string value);
    partial void OnTenPhongChanged();
    partial void OnGhiChuChanging(string value);
    partial void OnGhiChuChanged();
    partial void OnNgayCapNhatChanging(System.DateTime value);
    partial void OnNgayCapNhatChanged();
    #endregion
		
		public Phong()
		{
			this._KhuVucPhong = default(EntityRef<KhuVucPhong>);
			this._LoaiPhong = default(EntityRef<LoaiPhong>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaPhong", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaPhong
		{
			get
			{
				return this._MaPhong;
			}
			set
			{
				if ((this._MaPhong != value))
				{
					this.OnMaPhongChanging(value);
					this.SendPropertyChanging();
					this._MaPhong = value;
					this.SendPropertyChanged("MaPhong");
					this.OnMaPhongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaLP", DbType="Int NOT NULL")]
		public int MaLP
		{
			get
			{
				return this._MaLP;
			}
			set
			{
				if ((this._MaLP != value))
				{
					if (this._LoaiPhong.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaLPChanging(value);
					this.SendPropertyChanging();
					this._MaLP = value;
					this.SendPropertyChanged("MaLP");
					this.OnMaLPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKV", DbType="Int NOT NULL")]
		public int MaKV
		{
			get
			{
				return this._MaKV;
			}
			set
			{
				if ((this._MaKV != value))
				{
					if (this._KhuVucPhong.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaKVChanging(value);
					this.SendPropertyChanging();
					this._MaKV = value;
					this.SendPropertyChanged("MaKV");
					this.OnMaKVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenPhong", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TenPhong
		{
			get
			{
				return this._TenPhong;
			}
			set
			{
				if ((this._TenPhong != value))
				{
					this.OnTenPhongChanging(value);
					this.SendPropertyChanging();
					this._TenPhong = value;
					this.SendPropertyChanged("TenPhong");
					this.OnTenPhongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GhiChu", DbType="NVarChar(200)")]
		public string GhiChu
		{
			get
			{
				return this._GhiChu;
			}
			set
			{
				if ((this._GhiChu != value))
				{
					this.OnGhiChuChanging(value);
					this.SendPropertyChanging();
					this._GhiChu = value;
					this.SendPropertyChanged("GhiChu");
					this.OnGhiChuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="DateTime NOT NULL")]
		public System.DateTime NgayCapNhat
		{
			get
			{
				return this._NgayCapNhat;
			}
			set
			{
				if ((this._NgayCapNhat != value))
				{
					this.OnNgayCapNhatChanging(value);
					this.SendPropertyChanging();
					this._NgayCapNhat = value;
					this.SendPropertyChanged("NgayCapNhat");
					this.OnNgayCapNhatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhuVucPhong_Phong", Storage="_KhuVucPhong", ThisKey="MaKV", OtherKey="MaKV", IsForeignKey=true)]
		public KhuVucPhong KhuVucPhong
		{
			get
			{
				return this._KhuVucPhong.Entity;
			}
			set
			{
				KhuVucPhong previousValue = this._KhuVucPhong.Entity;
				if (((previousValue != value) 
							|| (this._KhuVucPhong.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KhuVucPhong.Entity = null;
						previousValue.Phongs.Remove(this);
					}
					this._KhuVucPhong.Entity = value;
					if ((value != null))
					{
						value.Phongs.Add(this);
						this._MaKV = value.MaKV;
					}
					else
					{
						this._MaKV = default(int);
					}
					this.SendPropertyChanged("KhuVucPhong");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiPhong_Phong", Storage="_LoaiPhong", ThisKey="MaLP", OtherKey="MaLP", IsForeignKey=true)]
		public LoaiPhong LoaiPhong
		{
			get
			{
				return this._LoaiPhong.Entity;
			}
			set
			{
				LoaiPhong previousValue = this._LoaiPhong.Entity;
				if (((previousValue != value) 
							|| (this._LoaiPhong.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LoaiPhong.Entity = null;
						previousValue.Phongs.Remove(this);
					}
					this._LoaiPhong.Entity = value;
					if ((value != null))
					{
						value.Phongs.Add(this);
						this._MaLP = value.MaLP;
					}
					else
					{
						this._MaLP = default(int);
					}
					this.SendPropertyChanged("LoaiPhong");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LoaiPhong")]
	public partial class LoaiPhong : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaLP;
		
		private string _TenLP;
		
		private string _GhiChu;
		
		private System.Nullable<System.DateTime> _NgayCapNhat;
		
		private EntitySet<Phong> _Phongs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaLPChanging(int value);
    partial void OnMaLPChanged();
    partial void OnTenLPChanging(string value);
    partial void OnTenLPChanged();
    partial void OnGhiChuChanging(string value);
    partial void OnGhiChuChanged();
    partial void OnNgayCapNhatChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayCapNhatChanged();
    #endregion
		
		public LoaiPhong()
		{
			this._Phongs = new EntitySet<Phong>(new Action<Phong>(this.attach_Phongs), new Action<Phong>(this.detach_Phongs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaLP", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaLP
		{
			get
			{
				return this._MaLP;
			}
			set
			{
				if ((this._MaLP != value))
				{
					this.OnMaLPChanging(value);
					this.SendPropertyChanging();
					this._MaLP = value;
					this.SendPropertyChanged("MaLP");
					this.OnMaLPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenLP", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TenLP
		{
			get
			{
				return this._TenLP;
			}
			set
			{
				if ((this._TenLP != value))
				{
					this.OnTenLPChanging(value);
					this.SendPropertyChanging();
					this._TenLP = value;
					this.SendPropertyChanged("TenLP");
					this.OnTenLPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GhiChu", DbType="NVarChar(200)")]
		public string GhiChu
		{
			get
			{
				return this._GhiChu;
			}
			set
			{
				if ((this._GhiChu != value))
				{
					this.OnGhiChuChanging(value);
					this.SendPropertyChanging();
					this._GhiChu = value;
					this.SendPropertyChanged("GhiChu");
					this.OnGhiChuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayCapNhat
		{
			get
			{
				return this._NgayCapNhat;
			}
			set
			{
				if ((this._NgayCapNhat != value))
				{
					this.OnNgayCapNhatChanging(value);
					this.SendPropertyChanging();
					this._NgayCapNhat = value;
					this.SendPropertyChanged("NgayCapNhat");
					this.OnNgayCapNhatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiPhong_Phong", Storage="_Phongs", ThisKey="MaLP", OtherKey="MaLP")]
		public EntitySet<Phong> Phongs
		{
			get
			{
				return this._Phongs;
			}
			set
			{
				this._Phongs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Phongs(Phong entity)
		{
			this.SendPropertyChanging();
			entity.LoaiPhong = this;
		}
		
		private void detach_Phongs(Phong entity)
		{
			this.SendPropertyChanging();
			entity.LoaiPhong = null;
		}
	}
}
#pragma warning restore 1591
