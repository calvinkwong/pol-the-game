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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PoL.Logic.Views;
using PoL.Common;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.WinFormsView.Utils;
using PoL.WinFormsView.Properties;
using PoL.Logic.Controllers;
using System.Diagnostics;

namespace PoL.WinFormsView.Game
{
  public partial class CardView : UserControl, ILocalizable
  {
    public const int BORDER_SIZE = 2;
    Image cardFrontImage;
    static Image cardBackImage;
    List<string> tokensKeys;
    CardViewItem cardViewItem;
    Rectangle tokensRect;
    FlowLayoutPanel pnlTokens;
    bool enableRotation;
    Panel pnlCard;
    CardPosition position;

    bool selected;

    public CardView()
    {
      InitializeComponent();

      pnlCard = new Panel();
      pnlCard.BackgroundImageLayout = ImageLayout.Center;
      pnlCard.BackColor = Color.White;
      this.Controls.Add(pnlCard);
      pnlCard.Location = new Point(BORDER_SIZE, BORDER_SIZE);

      pnlTokens = new FlowLayoutPanel();
      pnlTokens.BackColor = Color.Transparent;
      pnlCard.Controls.Add(pnlTokens);
      
      tokensKeys = new List<string>();

      toolTip.Popup += new PopupEventHandler(toolTip_Popup);

      menu.Opening += new CancelEventHandler(menu_Opening);
      menuChangeText.Click += delegate(object sender, EventArgs e)
      {
        ShowTokenDialog((TokenView)GetMenuTarget((ToolStripMenuItem)sender));
      };
      menuRemove.Click += delegate(object sender, EventArgs e)
      {
        GameView.Controller.RemoveToken(GetMenuTarget((ToolStripMenuItem)sender).Name);
      };

      Localize();
      
      if(cardBackImage == null)
        cardBackImage = Program.LogicHandler.ServicesProvider.ImagesService.GetCardBack(CardStyleBehaviorsService.BEHAVIORS_SMALL);
      
      AttachSubControlsMouseEvents(this.Controls);

    }

    void toolTip_Popup(object sender, PopupEventArgs e)
    {
      try
      {
        e.Cancel = GameViewHelper.FindParentPlayerView(this).Name == cardViewItem.OwnerPlayerKey;
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public bool Selected
    {
      get { return selected; }
      set
      {
        selected = value;
        BackColor = selected ? Color.SeaGreen : Color.White;
      }
    }

    public CardPosition Position
    {
      get { return position; }
    }

    GameView GameView
    {
      get { return (GameView)FindForm();  }
    }

    void menu_Opening(object sender, CancelEventArgs e)
    {
      try
      {
        e.Cancel = !GameView.IsSolitaire && GameView.ActivePlayerKey != GameViewHelper.FindParentPlayerView(this).Name;
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void AttachSubControlsMouseEvents(ControlCollection controls)
    {
      foreach(Control ctrl in controls)
      {
        ctrl.MouseDown += delegate(object sender, MouseEventArgs e) { OnMouseDown(e); };
        ctrl.MouseUp += delegate(object sender, MouseEventArgs e) { OnMouseUp(e); };
        ctrl.MouseMove += delegate(object sender, MouseEventArgs e) { OnMouseMove(e); };
        ctrl.DoubleClick += delegate(object sender, EventArgs e) { OnDoubleClick(e); };
        ctrl.Click += delegate(object sender, EventArgs e) { OnClick(e); };
        ctrl.MouseHover += delegate(object sender, EventArgs e) { OnMouseHover(e); };
        AttachSubControlsMouseEvents(ctrl.Controls);
      }
    }

    public void Localize()
    {
      menuChangeText.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_MENU", "EDIT");
      menuRemove.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_MENU", "REMOVE");
    }

    void CreateAndCacheImage()
    {
      if(GameViewHelper.FindParentSectorView(this) is SimpleSectorView)
        this.cardFrontImage = new Bitmap(CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL).Size.Width,
          CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL).Size.Height);
      else
      {
        this.cardFrontImage = CardDrawer.Draw(cardViewItem.Data, 
          cardViewItem.CustomCharacteristics, CardStyleBehaviorsService.BEHAVIORS_SMALL);
      }
    }

    void ShowTokenDialog(TokenView token)
    {
      TokenEditor dlg = new TokenEditor(token.TokenText, token.TokenAmount, token.TokenColor);
      dlg.StartPosition = FormStartPosition.CenterScreen;
      if(dlg.ShowDialog(this) == DialogResult.OK)
      {
        if(token.TokenText != dlg.TokenText)
          GameView.Controller.SetTokenText(token.Name, dlg.TokenText);
        if(token.TokenAmount != dlg.TokenAmount)
          GameView.Controller.SetTokenAmount(token.Name, dlg.TokenAmount);
        if(token.TokenColor != dlg.TokenColor)
          GameView.Controller.SetTokenColor(token.Name, dlg.TokenColor);
      }
    }

    protected TokenView GetMenuTarget(ToolStripMenuItem menuItem)
    {
      ContextMenuStrip menu = (ContextMenuStrip)menuItem.Owner;
      return (TokenView)menu.SourceControl;
    }

    protected override void OnDoubleClick(EventArgs e)
    {
      try
      {
        base.OnDoubleClick(e);
        if(enableRotation)
          GameView.Controller.RotateCards(Enumerable.Repeat(Name, 1).ToList());
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    protected override void OnMouseHover(EventArgs e)
    {
      try
      {
        base.OnMouseHover(e);
        if(cardViewItem.Visibility == CardVisibility.Visible ||
          (cardViewItem.Visibility == CardVisibility.Private && ((PlayerView)GameViewHelper.FindParentPlayerView(this)).IsActivePlayer))
          GameView.ShowCardMagnification(cardViewItem.Data);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public bool EnableRotation
    {
      get { return enableRotation; }
      set { enableRotation = value; }
    }

    public CardViewItem CardViewItem
    {
      get { return cardViewItem; }
    }

    public void SetCard(CardViewItem card)
    {
      cardViewItem = card.Clone();
      this.SetPosition(cardViewItem.Position);

      string ownerName = this.GameView.GameStructure.GetPlayer(cardViewItem.OwnerPlayerKey).Item.NickName;
      toolTip.SetToolTip(this, ownerName);
      toolTip.SetToolTip(pnlCard, ownerName);
      toolTip.SetToolTip(pnlTokens, ownerName);
      tokensRect = CardMetricsService.TextRect(cardViewItem.Data.StyleCode, CardStyleBehaviorsService.BEHAVIORS_SMALL);
      CreateAndCacheImage();
      ApplyCardBehavior();
    }

    //Stopwatch sw = new Stopwatch();
    public void UpdateCard(CardItem cardItem)
    {
      //Debug.WriteLine("Start update");
      //sw.Start();
      cardViewItem.Data = cardItem;
      //Debug.WriteLine("CreateAndCacheImage() start at " + sw.ElapsedTicks);
      CreateAndCacheImage();
      //Debug.WriteLine("CreateAndCacheImage() end at " + sw.ElapsedTicks);
      //Debug.WriteLine("ApplyCardBehavior() start at " + sw.ElapsedTicks);
      ApplyCardBehavior();
      //Debug.WriteLine("ApplyCardBehavior() end at " + sw.ElapsedTicks);
      //sw.Stop();
    }

    public void SetReversed(bool reversed)
    {
      cardViewItem.Reversed = reversed;
      ApplyCardBehavior();
    }

    public void SetVisibility(CardVisibility visibility, int hiddenCode)
    {
      cardViewItem.Visibility = visibility;
      cardViewItem.HiddenCode = hiddenCode;
      ApplyCardBehavior();
    }

    public void SetRotation(bool rotated)
    {
      cardViewItem.Rotated = rotated;
      ApplyCardBehavior();
    }

    public void SetLockState(bool lockState)
    {
      cardViewItem.Locked = lockState;
    }

    public void SetPosition(CardPosition position)
    {
      this.position = position;
      //this.Location = new Point((int)position.X, (int)position.Y);
      Point location = new Point((int)(this.Parent.ClientSize.Width * position.X), (int)(this.Parent.ClientSize.Height * position.Y));
      if(!GameView.IsSolitaire)
      {
        var playerView = GameViewHelper.FindParentPlayerView(this);
        if(playerView != null && !playerView.IsActivePlayer)
          location = new Point(location.X,
            this.Parent.ClientSize.Height - location.Y - CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL).Height);
      }
      this.Location = location;
    }

    public void SetCustomCharacteristics(string characteristics)
    {
      if(cardViewItem.CustomCharacteristics != characteristics)
      {
        cardViewItem.CustomCharacteristics = characteristics;
        CreateAndCacheImage();
        ApplyCardBehavior();
      }
    }

    public IEnumerable<string> TokenKeys
    {
      get { return tokensKeys; }
    }

    public void AddToken(string key, string text, int amount, TokenColor color)
    {
      TokenView tokenView = new TokenView();
      tokenView.Name = key;
      tokenView.ContextMenuStrip = menu;
      tokenView.TokenText = text;
      tokenView.TokenColor = color;
      tokenView.TokenAmount = amount;
      tokenView.DoubleClick += new EventHandler(tokenView_DoubleClick);
      pnlTokens.Controls.Add(tokenView);
      tokensKeys.Add(key);
    }

    public void RemoveToken(string key)
    {
      pnlTokens.Controls.RemoveByKey(key);
      tokensKeys.Remove(key);
    }

    public void SetTokenText(string key, string text)
    {
      TokenView token = (TokenView)this.Controls.Find(key, true).First();
      token.TokenText = text;
    }

    public void SetTokenAmount(string key, int amount)
    {
      TokenView token = (TokenView)this.Controls.Find(key, true).First();
      token.TokenAmount = amount;
    }

    public void SetTokenColor(string key, TokenColor color)
    {
      TokenView token = (TokenView)this.Controls.Find(key, true).First();
      token.TokenColor = color;
    }

    void tokenView_DoubleClick(object sender, EventArgs e)
    {
      if(GameView.IsSolitaire || GameView.ActivePlayerKey == GameViewHelper.FindParentPlayerView(this).Name)
        ShowTokenDialog((TokenView)sender);
    }

    void ApplyCardBehavior()
    {
      bool showHiddenCode = false;
      Image image = null;
      switch(cardViewItem.Visibility)
      {
        case CardVisibility.Visible:
          image = (Image)cardFrontImage.Clone();
          break;
        case CardVisibility.Private:
          if(((PlayerView)GameViewHelper.FindParentPlayerView(this)).IsActivePlayer)
            image = CursorCreator.CreateOpaqueBitmap(cardFrontImage, 0.4f);
          else
          {
            image = CursorCreator.CreateOpaqueBitmap(cardBackImage, 0.4f);
            showHiddenCode = true;
          }
          break;
        case CardVisibility.Hidden:
          image = (Image)cardBackImage.Clone();
          showHiddenCode = true;
          break;
      }

      if(showHiddenCode)
        using(Graphics g = Graphics.FromImage(image))
        {
          RectangleF hiddenCodeRect = new RectangleF(image.Width / 2f - 16f, image.Height / 2f - 32f, 32f, 32f);
          g.DrawImage(Resources.stock_signature, hiddenCodeRect);
          using(Font f = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Pixel))
          {
            SizeF stringSize = g.MeasureString(cardViewItem.HiddenCode.ToString(), f);
            g.DrawString(cardViewItem.HiddenCode.ToString(), f, new SolidBrush(Color.White),
              image.Width / 2f - stringSize.Width / 2f, image.Height / 2f - 16f - stringSize.Height / 2f);
          }
        }

      if(pnlCard.BackgroundImage != null)
        pnlCard.BackgroundImage.Dispose();
      pnlCard.BackgroundImage = image;

      if(cardViewItem.Rotated)
      {
        if(cardViewItem.Reversed)
          pnlCard.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        else
          pnlCard.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
      }
      else
      {
        if(cardViewItem.Reversed)
          pnlCard.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
      }
      this.Size = new Size(pnlCard.BackgroundImage.Size.Width + (BORDER_SIZE*2), pnlCard.BackgroundImage.Size.Height + (BORDER_SIZE*2));
      pnlCard.Size = new Size(pnlCard.BackgroundImage.Size.Width, pnlCard.BackgroundImage.Size.Height);
      Refresh();

      Rectangle textRect = CardMetricsService.TextRect(cardViewItem.Data.StyleCode, CardStyleBehaviorsService.BEHAVIORS_SMALL);
      Rectangle cardRect = CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL);
      if(cardViewItem.Rotated)
      {
        tokensRect.Size = new Size(textRect.Size.Height, textRect.Size.Width);
        if(cardViewItem.Reversed)
          tokensRect.Location = new Point(cardRect.Height - textRect.Height, textRect.X);
        else
          tokensRect.Location = new Point(cardRect.Height - textRect.Bottom, textRect.X);
      }
      else
      {
        tokensRect.Size = textRect.Size;
        if(cardViewItem.Reversed)
          tokensRect.Location = new Point(textRect.X, cardRect.Height - textRect.Bottom);
        else
          tokensRect.Location = textRect.Location;
      }
      pnlTokens.Bounds = tokensRect;
    }    
  }
}
