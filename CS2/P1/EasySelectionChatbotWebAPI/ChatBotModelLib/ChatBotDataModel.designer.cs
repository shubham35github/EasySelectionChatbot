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

namespace ChatBotModelLib
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ChatbotDB")]
	public partial class ChatBotDataModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertMonitor(Monitor instance);
    partial void UpdateMonitor(Monitor instance);
    partial void DeleteMonitor(Monitor instance);
    partial void InsertMonitorsPreference(MonitorsPreference instance);
    partial void UpdateMonitorsPreference(MonitorsPreference instance);
    partial void DeleteMonitorsPreference(MonitorsPreference instance);
    #endregion
		
		public ChatBotDataModelDataContext() : 
				base(global::ChatBotModelLib.Properties.Settings.Default.ChatbotDBConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public ChatBotDataModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ChatBotDataModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ChatBotDataModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ChatBotDataModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<Monitor> Monitors
		{
			get
			{
				return this.GetTable<Monitor>();
			}
		}
		
		public System.Data.Linq.Table<MonitorsPreference> MonitorsPreferences
		{
			get
			{
				return this.GetTable<MonitorsPreference>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _customer_name;
		
		private string _customer_email;
		
		private string _customer_phone;
		
		private EntitySet<MonitorsPreference> _MonitorsPreferences;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncustomer_nameChanging(string value);
    partial void Oncustomer_nameChanged();
    partial void Oncustomer_emailChanging(string value);
    partial void Oncustomer_emailChanged();
    partial void Oncustomer_phoneChanging(string value);
    partial void Oncustomer_phoneChanged();
    #endregion
		
		public Customer()
		{
			this._MonitorsPreferences = new EntitySet<MonitorsPreference>(new Action<MonitorsPreference>(this.attach_MonitorsPreferences), new Action<MonitorsPreference>(this.detach_MonitorsPreferences));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_customer_name", DbType="NVarChar(255)")]
		public string customer_name
		{
			get
			{
				return this._customer_name;
			}
			set
			{
				if ((this._customer_name != value))
				{
					this.Oncustomer_nameChanging(value);
					this.SendPropertyChanging();
					this._customer_name = value;
					this.SendPropertyChanged("customer_name");
					this.Oncustomer_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_customer_email", DbType="NVarChar(255) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string customer_email
		{
			get
			{
				return this._customer_email;
			}
			set
			{
				if ((this._customer_email != value))
				{
					this.Oncustomer_emailChanging(value);
					this.SendPropertyChanging();
					this._customer_email = value;
					this.SendPropertyChanged("customer_email");
					this.Oncustomer_emailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_customer_phone", DbType="VarChar(10)")]
		public string customer_phone
		{
			get
			{
				return this._customer_phone;
			}
			set
			{
				if ((this._customer_phone != value))
				{
					this.Oncustomer_phoneChanging(value);
					this.SendPropertyChanging();
					this._customer_phone = value;
					this.SendPropertyChanged("customer_phone");
					this.Oncustomer_phoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_MonitorsPreference", Storage="_MonitorsPreferences", ThisKey="customer_email", OtherKey="customer_email")]
		public EntitySet<MonitorsPreference> MonitorsPreferences
		{
			get
			{
				return this._MonitorsPreferences;
			}
			set
			{
				this._MonitorsPreferences.Assign(value);
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
		
		private void attach_MonitorsPreferences(MonitorsPreference entity)
		{
			this.SendPropertyChanging();
			entity.Customer = this;
		}
		
		private void detach_MonitorsPreferences(MonitorsPreference entity)
		{
			this.SendPropertyChanging();
			entity.Customer = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Monitors")]
	public partial class Monitor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _monitors_no;
		
		private string _measurment;
		
		private string _touchscreen;
		
		private string _category;
		
		private string _portablity_1;
		
		private string _feature_1;
		
		private string _size_1;
		
		private string _feature_2;
		
		private string _feature_3;
		
		private string _portablity_2;
		
		private string _ante_intrapartum;
		
		private string _display_mode;
		
		private string _weights;
		
		private string _feature_4;
		
		private string _invasive_bp;
		
		private string _co2_measurment;
		
		private string _nbp_measurment;
		
		private string _speed;
		
		private string _storage_size;
		
		private string _monitors_name;
		
		private EntitySet<MonitorsPreference> _MonitorsPreferences;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onmonitors_noChanging(int value);
    partial void Onmonitors_noChanged();
    partial void OnmeasurmentChanging(string value);
    partial void OnmeasurmentChanged();
    partial void OntouchscreenChanging(string value);
    partial void OntouchscreenChanged();
    partial void OncategoryChanging(string value);
    partial void OncategoryChanged();
    partial void Onportablity_1Changing(string value);
    partial void Onportablity_1Changed();
    partial void Onfeature_1Changing(string value);
    partial void Onfeature_1Changed();
    partial void Onsize_1Changing(string value);
    partial void Onsize_1Changed();
    partial void Onfeature_2Changing(string value);
    partial void Onfeature_2Changed();
    partial void Onfeature_3Changing(string value);
    partial void Onfeature_3Changed();
    partial void Onportablity_2Changing(string value);
    partial void Onportablity_2Changed();
    partial void Onante_intrapartumChanging(string value);
    partial void Onante_intrapartumChanged();
    partial void Ondisplay_modeChanging(string value);
    partial void Ondisplay_modeChanged();
    partial void OnweightsChanging(string value);
    partial void OnweightsChanged();
    partial void Onfeature_4Changing(string value);
    partial void Onfeature_4Changed();
    partial void Oninvasive_bpChanging(string value);
    partial void Oninvasive_bpChanged();
    partial void Onco2_measurmentChanging(string value);
    partial void Onco2_measurmentChanged();
    partial void Onnbp_measurmentChanging(string value);
    partial void Onnbp_measurmentChanged();
    partial void OnspeedChanging(string value);
    partial void OnspeedChanged();
    partial void Onstorage_sizeChanging(string value);
    partial void Onstorage_sizeChanged();
    partial void Onmonitors_nameChanging(string value);
    partial void Onmonitors_nameChanged();
    #endregion
		
		public Monitor()
		{
			this._MonitorsPreferences = new EntitySet<MonitorsPreference>(new Action<MonitorsPreference>(this.attach_MonitorsPreferences), new Action<MonitorsPreference>(this.detach_MonitorsPreferences));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_monitors_no", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int monitors_no
		{
			get
			{
				return this._monitors_no;
			}
			set
			{
				if ((this._monitors_no != value))
				{
					this.Onmonitors_noChanging(value);
					this.SendPropertyChanging();
					this._monitors_no = value;
					this.SendPropertyChanged("monitors_no");
					this.Onmonitors_noChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_measurment", DbType="NVarChar(255)")]
		public string measurment
		{
			get
			{
				return this._measurment;
			}
			set
			{
				if ((this._measurment != value))
				{
					this.OnmeasurmentChanging(value);
					this.SendPropertyChanging();
					this._measurment = value;
					this.SendPropertyChanged("measurment");
					this.OnmeasurmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_touchscreen", DbType="NVarChar(255)")]
		public string touchscreen
		{
			get
			{
				return this._touchscreen;
			}
			set
			{
				if ((this._touchscreen != value))
				{
					this.OntouchscreenChanging(value);
					this.SendPropertyChanging();
					this._touchscreen = value;
					this.SendPropertyChanged("touchscreen");
					this.OntouchscreenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", DbType="NVarChar(255)")]
		public string category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					this.OncategoryChanging(value);
					this.SendPropertyChanging();
					this._category = value;
					this.SendPropertyChanged("category");
					this.OncategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_portablity_1", DbType="NVarChar(255)")]
		public string portablity_1
		{
			get
			{
				return this._portablity_1;
			}
			set
			{
				if ((this._portablity_1 != value))
				{
					this.Onportablity_1Changing(value);
					this.SendPropertyChanging();
					this._portablity_1 = value;
					this.SendPropertyChanged("portablity_1");
					this.Onportablity_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feature_1", DbType="NVarChar(255)")]
		public string feature_1
		{
			get
			{
				return this._feature_1;
			}
			set
			{
				if ((this._feature_1 != value))
				{
					this.Onfeature_1Changing(value);
					this.SendPropertyChanging();
					this._feature_1 = value;
					this.SendPropertyChanged("feature_1");
					this.Onfeature_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_size_1", DbType="NVarChar(255)")]
		public string size_1
		{
			get
			{
				return this._size_1;
			}
			set
			{
				if ((this._size_1 != value))
				{
					this.Onsize_1Changing(value);
					this.SendPropertyChanging();
					this._size_1 = value;
					this.SendPropertyChanged("size_1");
					this.Onsize_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feature_2", DbType="NVarChar(255)")]
		public string feature_2
		{
			get
			{
				return this._feature_2;
			}
			set
			{
				if ((this._feature_2 != value))
				{
					this.Onfeature_2Changing(value);
					this.SendPropertyChanging();
					this._feature_2 = value;
					this.SendPropertyChanged("feature_2");
					this.Onfeature_2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feature_3", DbType="NVarChar(255)")]
		public string feature_3
		{
			get
			{
				return this._feature_3;
			}
			set
			{
				if ((this._feature_3 != value))
				{
					this.Onfeature_3Changing(value);
					this.SendPropertyChanging();
					this._feature_3 = value;
					this.SendPropertyChanged("feature_3");
					this.Onfeature_3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_portablity_2", DbType="NVarChar(255)")]
		public string portablity_2
		{
			get
			{
				return this._portablity_2;
			}
			set
			{
				if ((this._portablity_2 != value))
				{
					this.Onportablity_2Changing(value);
					this.SendPropertyChanging();
					this._portablity_2 = value;
					this.SendPropertyChanged("portablity_2");
					this.Onportablity_2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ante/intrapartum]", Storage="_ante_intrapartum", DbType="NVarChar(255)")]
		public string ante_intrapartum
		{
			get
			{
				return this._ante_intrapartum;
			}
			set
			{
				if ((this._ante_intrapartum != value))
				{
					this.Onante_intrapartumChanging(value);
					this.SendPropertyChanging();
					this._ante_intrapartum = value;
					this.SendPropertyChanged("ante_intrapartum");
					this.Onante_intrapartumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_display_mode", DbType="NVarChar(255)")]
		public string display_mode
		{
			get
			{
				return this._display_mode;
			}
			set
			{
				if ((this._display_mode != value))
				{
					this.Ondisplay_modeChanging(value);
					this.SendPropertyChanging();
					this._display_mode = value;
					this.SendPropertyChanged("display_mode");
					this.Ondisplay_modeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_weights", DbType="NVarChar(255)")]
		public string weights
		{
			get
			{
				return this._weights;
			}
			set
			{
				if ((this._weights != value))
				{
					this.OnweightsChanging(value);
					this.SendPropertyChanging();
					this._weights = value;
					this.SendPropertyChanged("weights");
					this.OnweightsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feature_4", DbType="NVarChar(255)")]
		public string feature_4
		{
			get
			{
				return this._feature_4;
			}
			set
			{
				if ((this._feature_4 != value))
				{
					this.Onfeature_4Changing(value);
					this.SendPropertyChanging();
					this._feature_4 = value;
					this.SendPropertyChanged("feature_4");
					this.Onfeature_4Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_invasive_bp", DbType="NVarChar(255)")]
		public string invasive_bp
		{
			get
			{
				return this._invasive_bp;
			}
			set
			{
				if ((this._invasive_bp != value))
				{
					this.Oninvasive_bpChanging(value);
					this.SendPropertyChanging();
					this._invasive_bp = value;
					this.SendPropertyChanged("invasive_bp");
					this.Oninvasive_bpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_co2_measurment", DbType="NVarChar(255)")]
		public string co2_measurment
		{
			get
			{
				return this._co2_measurment;
			}
			set
			{
				if ((this._co2_measurment != value))
				{
					this.Onco2_measurmentChanging(value);
					this.SendPropertyChanging();
					this._co2_measurment = value;
					this.SendPropertyChanged("co2_measurment");
					this.Onco2_measurmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nbp_measurment", DbType="NVarChar(255)")]
		public string nbp_measurment
		{
			get
			{
				return this._nbp_measurment;
			}
			set
			{
				if ((this._nbp_measurment != value))
				{
					this.Onnbp_measurmentChanging(value);
					this.SendPropertyChanging();
					this._nbp_measurment = value;
					this.SendPropertyChanged("nbp_measurment");
					this.Onnbp_measurmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_speed", DbType="NVarChar(255)")]
		public string speed
		{
			get
			{
				return this._speed;
			}
			set
			{
				if ((this._speed != value))
				{
					this.OnspeedChanging(value);
					this.SendPropertyChanging();
					this._speed = value;
					this.SendPropertyChanged("speed");
					this.OnspeedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_storage_size", DbType="NVarChar(255)")]
		public string storage_size
		{
			get
			{
				return this._storage_size;
			}
			set
			{
				if ((this._storage_size != value))
				{
					this.Onstorage_sizeChanging(value);
					this.SendPropertyChanging();
					this._storage_size = value;
					this.SendPropertyChanged("storage_size");
					this.Onstorage_sizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_monitors_name", DbType="NVarChar(255)")]
		public string monitors_name
		{
			get
			{
				return this._monitors_name;
			}
			set
			{
				if ((this._monitors_name != value))
				{
					this.Onmonitors_nameChanging(value);
					this.SendPropertyChanging();
					this._monitors_name = value;
					this.SendPropertyChanged("monitors_name");
					this.Onmonitors_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Monitor_MonitorsPreference", Storage="_MonitorsPreferences", ThisKey="monitors_no", OtherKey="monitors_no")]
		public EntitySet<MonitorsPreference> MonitorsPreferences
		{
			get
			{
				return this._MonitorsPreferences;
			}
			set
			{
				this._MonitorsPreferences.Assign(value);
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
		
		private void attach_MonitorsPreferences(MonitorsPreference entity)
		{
			this.SendPropertyChanging();
			entity.Monitor = this;
		}
		
		private void detach_MonitorsPreferences(MonitorsPreference entity)
		{
			this.SendPropertyChanging();
			entity.Monitor = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MonitorsPreference")]
	public partial class MonitorsPreference : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _customer_email;
		
		private int _monitors_no;
		
		private System.DateTime _check_in;
		
		private EntityRef<Customer> _Customer;
		
		private EntityRef<Monitor> _Monitor;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncustomer_emailChanging(string value);
    partial void Oncustomer_emailChanged();
    partial void Onmonitors_noChanging(int value);
    partial void Onmonitors_noChanged();
    partial void Oncheck_inChanging(System.DateTime value);
    partial void Oncheck_inChanged();
    #endregion
		
		public MonitorsPreference()
		{
			this._Customer = default(EntityRef<Customer>);
			this._Monitor = default(EntityRef<Monitor>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_customer_email", DbType="NVarChar(255) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string customer_email
		{
			get
			{
				return this._customer_email;
			}
			set
			{
				if ((this._customer_email != value))
				{
					if (this._Customer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncustomer_emailChanging(value);
					this.SendPropertyChanging();
					this._customer_email = value;
					this.SendPropertyChanged("customer_email");
					this.Oncustomer_emailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_monitors_no", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int monitors_no
		{
			get
			{
				return this._monitors_no;
			}
			set
			{
				if ((this._monitors_no != value))
				{
					if (this._Monitor.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onmonitors_noChanging(value);
					this.SendPropertyChanging();
					this._monitors_no = value;
					this.SendPropertyChanged("monitors_no");
					this.Onmonitors_noChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_check_in", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime check_in
		{
			get
			{
				return this._check_in;
			}
			set
			{
				if ((this._check_in != value))
				{
					this.Oncheck_inChanging(value);
					this.SendPropertyChanging();
					this._check_in = value;
					this.SendPropertyChanged("check_in");
					this.Oncheck_inChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_MonitorsPreference", Storage="_Customer", ThisKey="customer_email", OtherKey="customer_email", IsForeignKey=true)]
		public Customer Customer
		{
			get
			{
				return this._Customer.Entity;
			}
			set
			{
				Customer previousValue = this._Customer.Entity;
				if (((previousValue != value) 
							|| (this._Customer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Customer.Entity = null;
						previousValue.MonitorsPreferences.Remove(this);
					}
					this._Customer.Entity = value;
					if ((value != null))
					{
						value.MonitorsPreferences.Add(this);
						this._customer_email = value.customer_email;
					}
					else
					{
						this._customer_email = default(string);
					}
					this.SendPropertyChanged("Customer");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Monitor_MonitorsPreference", Storage="_Monitor", ThisKey="monitors_no", OtherKey="monitors_no", IsForeignKey=true)]
		public Monitor Monitor
		{
			get
			{
				return this._Monitor.Entity;
			}
			set
			{
				Monitor previousValue = this._Monitor.Entity;
				if (((previousValue != value) 
							|| (this._Monitor.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Monitor.Entity = null;
						previousValue.MonitorsPreferences.Remove(this);
					}
					this._Monitor.Entity = value;
					if ((value != null))
					{
						value.MonitorsPreferences.Add(this);
						this._monitors_no = value.monitors_no;
					}
					else
					{
						this._monitors_no = default(int);
					}
					this.SendPropertyChanged("Monitor");
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
}
#pragma warning restore 1591
