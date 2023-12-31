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

namespace ClientSideConnect4
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GameDB")]
	public partial class UsersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertMove(Move instance);
    partial void UpdateMove(Move instance);
    partial void DeleteMove(Move instance);
    partial void InsertGame(Game instance);
    partial void UpdateGame(Game instance);
    partial void DeleteGame(Game instance);
    #endregion
		
		public UsersDataContext() : 
				base(global::ClientSideConnect4.Properties.Settings.Default.GameDBConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Move> Moves
		{
			get
			{
				return this.GetTable<Move>();
			}
		}
		
		public System.Data.Linq.Table<Game> Games
		{
			get
			{
				return this.GetTable<Game>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Move")]
	public partial class Move : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MoveID;
		
		private int _MoveNum;
		
		private int _Column;
		
		private bool _isPlayer;
		
		private int _GameID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMoveIDChanging(int value);
    partial void OnMoveIDChanged();
    partial void OnMoveNumChanging(int value);
    partial void OnMoveNumChanged();
    partial void OnColumnChanging(int value);
    partial void OnColumnChanged();
    partial void OnisPlayerChanging(bool value);
    partial void OnisPlayerChanged();
    partial void OnGameIDChanging(int value);
    partial void OnGameIDChanged();
    #endregion
		
		public Move()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoveID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MoveID
		{
			get
			{
				return this._MoveID;
			}
			set
			{
				if ((this._MoveID != value))
				{
					this.OnMoveIDChanging(value);
					this.SendPropertyChanging();
					this._MoveID = value;
					this.SendPropertyChanged("MoveID");
					this.OnMoveIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoveNum", DbType="Int NOT NULL")]
		public int MoveNum
		{
			get
			{
				return this._MoveNum;
			}
			set
			{
				if ((this._MoveNum != value))
				{
					this.OnMoveNumChanging(value);
					this.SendPropertyChanging();
					this._MoveNum = value;
					this.SendPropertyChanged("MoveNum");
					this.OnMoveNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Column]", Storage="_Column", DbType="Int NOT NULL")]
		public int Column
		{
			get
			{
				return this._Column;
			}
			set
			{
				if ((this._Column != value))
				{
					this.OnColumnChanging(value);
					this.SendPropertyChanging();
					this._Column = value;
					this.SendPropertyChanged("Column");
					this.OnColumnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isPlayer", DbType="Bit NOT NULL")]
		public bool isPlayer
		{
			get
			{
				return this._isPlayer;
			}
			set
			{
				if ((this._isPlayer != value))
				{
					this.OnisPlayerChanging(value);
					this.SendPropertyChanging();
					this._isPlayer = value;
					this.SendPropertyChanged("isPlayer");
					this.OnisPlayerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameID", DbType="Int NOT NULL")]
		public int GameID
		{
			get
			{
				return this._GameID;
			}
			set
			{
				if ((this._GameID != value))
				{
					this.OnGameIDChanging(value);
					this.SendPropertyChanging();
					this._GameID = value;
					this.SendPropertyChanged("GameID");
					this.OnGameIDChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Game")]
	public partial class Game : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _GameID;
		
		private int _PlayerID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGameIDChanging(int value);
    partial void OnGameIDChanged();
    partial void OnPlayerIDChanging(int value);
    partial void OnPlayerIDChanged();
    #endregion
		
		public Game()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int GameID
		{
			get
			{
				return this._GameID;
			}
			set
			{
				if ((this._GameID != value))
				{
					this.OnGameIDChanging(value);
					this.SendPropertyChanging();
					this._GameID = value;
					this.SendPropertyChanged("GameID");
					this.OnGameIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerID", DbType="Int NOT NULL")]
		public int PlayerID
		{
			get
			{
				return this._PlayerID;
			}
			set
			{
				if ((this._PlayerID != value))
				{
					this.OnPlayerIDChanging(value);
					this.SendPropertyChanging();
					this._PlayerID = value;
					this.SendPropertyChanged("PlayerID");
					this.OnPlayerIDChanged();
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
