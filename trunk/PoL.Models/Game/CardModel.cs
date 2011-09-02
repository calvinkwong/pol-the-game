/*
PoL - The polyhedral card game simulator
Copyright (C) 2011 Andrea Biagini

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using PoL.Common;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Services.DataExceptions;
using Patterns;
using Patterns.ComponentModel;

namespace PoL.Models.Game
{
  [Serializable]
  public class CardModel : Model
  {
    public readonly CardItem Data;
    public readonly ObservableProperty<bool, CardModel> Rotated;
    public readonly ObservableProperty<CardPosition, CardModel> Position;
    public readonly ObservableProperty<CardVisibility, CardModel> Visibility;
    public readonly ObservableProperty<bool, CardModel> Reversed;
    public readonly ObservableProperty<bool, CardModel> Locked;
    public readonly ObservableProperty<string, CardModel> CustomCharacteristics;
    public readonly ModelCollection Tokens;

    bool oldRotated;
    CardPosition oldPosition;
    CardVisibility oldVisibility;
    bool oldReversed;
    bool oldLocked;
    string oldCustomCharacteristics;
    List<Model> oldTokens;

    public readonly bool IsPawn;
    public int hiddenCode;

    static List<int> hiddenCardCodes = new List<int>();

    [NonSerialized]
    EventHandler dataChanged;

    public event EventHandler DataChanged
    {
      add { dataChanged = (EventHandler)Delegate.Combine(dataChanged, value); }
      remove { dataChanged = (EventHandler)Delegate.Remove(dataChanged, value); }
    }

    public CardModel(string key, PlayerModel owner, CardItem data, bool isPawn)
      : base(owner, key)
    {
      Data = data;
      IsPawn = isPawn;
      Position = new ObservableProperty<CardPosition, CardModel>(this, new CardPosition(0, 0));
      Visibility = new ObservableProperty<CardVisibility, CardModel>(this, CardVisibility.Visible);
      Reversed = new ObservableProperty<bool, CardModel>(this, false);
      Locked = new ObservableProperty<bool, CardModel>(this, false);
      Rotated = new ObservableProperty<bool, CardModel>(this, false);
      CustomCharacteristics = new ObservableProperty<string, CardModel>(this, string.Empty);
      Tokens = new ModelCollection(this);

      SaveState();

      this.Visibility.Changed += new EventHandler<ChangedEventArgs<CardVisibility>>(Visibility_Changed);
    }

    public void Reset()
    {
      SaveState();

      this.Position.Value = new CardPosition(0, 0);
      this.Visibility.Value = CardVisibility.Visible;
      this.Reversed.Value = false;
      this.Locked.Value = false;
      this.Rotated.Value = false;
      this.CustomCharacteristics.Value = string.Empty;
      this.Tokens.Clear();
    }

    public void Resume()
    {
      this.Position.Value = oldPosition;
      this.Visibility.Value = oldVisibility;
      this.Reversed.Value = oldReversed = this.Reversed.Value;
      this.Locked.Value = oldLocked;
      this.Rotated.Value = oldRotated;
      this.CustomCharacteristics.Value = oldCustomCharacteristics;
      foreach(var model in oldTokens)
        this.Tokens.Add(model);
    }

    public int HiddenCode
    {
      get { return hiddenCode; }
    }

    public void UpdateData(CardItem newData)
    {
      Data.Name = newData.Name;
      Data.Text = newData.Text;
      Data.FlavorText = newData.FlavorText;
      Data.Type = newData.Type;

      OnDataChanged();
    }

    public SmartName GetHiddenName()
    {
      string name = hiddenCode == 0 ? "???" : string.Concat("card n.", hiddenCode.ToString(), "");
      return new SmartName(name, false);
    }

    public SmartName GetVisibleName()
    {
      return new SmartName(this.Data.Name, true);
    }

    public SmartName GetSmartName()
    {
      SmartName smartName = GetHiddenName();
      if(this.Parent != null)
      {
        SectorModel sector = (SectorModel)this.Parent;
        PlayerModel player = (PlayerModel)sector.Parent;
        GameModel game = (GameModel)player.Parent;
        if(sector.Data.CardsVisibility == SectorCardsVisibility.Visibile ||
          (sector.Data.CardsVisibility == SectorCardsVisibility.Private && this.Owner.Key == game.ActivePlayer.Key))
        {
          if(this.Visibility.Value == CardVisibility.Visible ||
            (this.Visibility.Value == CardVisibility.Private && game.ActivePlayer.Key == this.Owner.Key))
          {
            smartName = GetVisibleName();
          }
        }
      }
      return smartName;
    }

    protected virtual void OnDataChanged()
    {
      if(dataChanged != null)
        dataChanged(this, EventArgs.Empty);
    }

    void SaveState()
    {
      oldPosition = this.Position.Value;
      oldVisibility = this.Visibility.Value;
      oldReversed = this.Reversed.Value;
      oldLocked = this.Locked.Value;
      oldRotated = this.Rotated.Value;
      oldCustomCharacteristics = this.CustomCharacteristics.Value;
      oldTokens = this.Tokens.ToList();
    }

    void Visibility_Changed(object sender, ChangedEventArgs<CardVisibility> e)
    {
      ObservableProperty<CardVisibility, CardModel> prop = (ObservableProperty<CardVisibility, CardModel>)sender;
      if(e.OldValue == CardVisibility.Visible && e.NewValue != CardVisibility.Visible)
        prop.Owner.hiddenCode = GetFirstAvaiableHiddenCode();
      else if(e.OldValue != CardVisibility.Visible && e.NewValue == CardVisibility.Visible)
      {
        MakeAvaiableHiddenCode(prop.Owner.hiddenCode);
        prop.Owner.hiddenCode = 0;
      }
    }

    static int GetFirstAvaiableHiddenCode()
    {
      int code = 1;
      while(hiddenCardCodes.Contains(code))
        code++;
      hiddenCardCodes.Add(code);
      return code;
    }

    static void MakeAvaiableHiddenCode(int code)
    {
      hiddenCardCodes.Remove(code);
    }

    public override string ToString()
    {
      return Key + " - " + Data.Name;
    }
  }
}
