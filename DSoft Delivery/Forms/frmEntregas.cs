using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftCore;

using DSoftModels;

using DSoftParameters;
using DSoft_Delivery.Relatorios;
using DSoft_Delivery.Forms;
using DSoftForms;

namespace DSoft_Delivery
{
	public partial class frmEntregas : Form
	{
		#region Fields

		public int NumeroPedido;

		private Bd _dsoftBd;
		private DataTable _pedidos;
		private Usuario _usuario;
		private Pedido _pedido;
		private Emitente _emitente;
		private Cliente _cliente;

		#endregion Fields

		#region Constructors

		public frmEntregas(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					ds = _dsoftBd.PedidosSemFechamento();
				}
				else
				{
					_dsoftBd.CarregarPedidos(ds);
				}

				_pedidos = ds.Tables[0];

				dgEntregas.DataSource = _pedidos;

				dgEntregas.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";

				dgEntregas.Columns["indice"].Width = 42;
				dgEntregas.Columns["indice"].HeaderText = "Índice";
				dgEntregas.Columns["data"].Width = 60;
				dgEntregas.Columns["data"].HeaderText = "Data";
				dgEntregas.Columns["hora"].Width = 60;
				dgEntregas.Columns["hora"].HeaderText = "Hora";
				dgEntregas.Columns["cliente"].Width = 60;
				dgEntregas.Columns["cliente"].HeaderText = "Cliente";
				dgEntregas.Columns["itens"].Width = 42;
				dgEntregas.Columns["itens"].HeaderText = "Itens";
				dgEntregas.Columns["total"].Width = 60;
				dgEntregas.Columns["total"].HeaderText = "Total";
				dgEntregas.Columns["observacao"].Width = 210;
				dgEntregas.Columns["observacao"].HeaderText = "Observação";
				dgEntregas.Columns["situacao"].Width = 60;
				dgEntregas.Columns["situacao"].HeaderText = "Sit.";
				dgEntregas.Columns["comanda"].HeaderText = "Comanda";
				dgEntregas.Columns["comanda"].Width = 30;
				dgEntregas.Columns["comanda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				dgEntregas.Columns["itens"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgEntregas.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					dgEntregas.Columns["comanda"].DisplayIndex = 0;
					dgEntregas.Columns["indice"].DisplayIndex = dgEntregas.Columns.Count - 1;
				}

				Util.Pintar(ref dgEntregas);

				if (dgEntregas.Rows.Count > 1)
				{
					dgEntregas.FirstDisplayedScrollingRowIndex = dgEntregas.Rows.Count - 1;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btPagar_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Saida();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Entrega();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			int pedido;
			int.TryParse(tbPedido.Text, out pedido);

			if (pedido < 1)
			{
				return;
			}

			DialogResult result = MessageBox.Show("Confirma o cancelamento do pedido de número " + pedido.ToString() + " ?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				if (_dsoftBd.CancelarPedido(pedido, "Cancelamento na entrega", _usuario.Codigo))
				{
					Atualizar();
					LimparCampos();
				}
			}
		}

		private bool CarregarPedido(int pedido)
		{
			try
			{
				char situacao;
				int itens;
				double valor;
				DateTime data;
				DateTime hora;
				int cliente;
				DateTime saida;
				DateTime entrega;
				int recurso;
				decimal taxa_entrega;
				string cliente_nome;
				string cliente_endereco;
				string cliente_bairro;
				char cliente_situacao;

				LimparCampos();

				if (_dsoftBd.CarregarDadosPedido(pedido, out situacao, out itens, out valor, out data, out hora, out cliente, out saida, out entrega, out recurso, out taxa_entrega))
				{
					tbPedido.Text = pedido.ToString();
					textBox3.Text = itens.ToString();
					textBox4.Text = valor.ToString("0.00");
					textBox6.Text = taxa_entrega.ToString("0.00");

					dateTimePicker1.Value = data;
					tbHoraPedido.Text = hora.ToString("HH:mm:ss");
					tbHoraPedido.Visible = true;

					if (saida <= DateTime.MinValue)
					{
						//dateTimePicker3.Visible = false;
						tbHoraSaida.Visible = false;
					}
					else
					{
						//dateTimePicker3.Visible = true;
						//dateTimePicker3.Value.Add(saida.TimeOfDay);
						tbHoraSaida.Visible = true;
						tbHoraSaida.Text = saida.ToString("HH:mm:ss");
					}

					if (entrega <= DateTime.MinValue)
					{
						//dateTimePicker4.Visible = false;
						tbHoraEntrega.Visible = false;
					}
					else
					{
						//dateTimePicker4.Visible = true;
						//dateTimePicker4.Value.Add(entrega.TimeOfDay);
						tbHoraEntrega.Visible = true;
						tbHoraEntrega.Text = entrega.ToString("HH:mm:ss");
					}

					textBox2.Text = cliente.ToString();

					_pedido = new Pedido();

					if (_dsoftBd.CarregarPedido(pedido, _pedido))
					{
						foreach (ItemPedido item in _pedido.ItensPedido)
						{
							tbDetalhes.AppendText(item.ToString() + Environment.NewLine);
						}
					}

					if (cliente > 0)
					{
						_cliente = _dsoftBd.CarregarCliente(cliente);

						cliente_nome = string.Empty;
						cliente_situacao = 'A';

						if (_dsoftBd.ClienteNome(cliente, out cliente_nome, out cliente_situacao))
						{
							lbCliente.Text = cliente_nome;
						}

						cliente_endereco = _cliente.Endereco;

						if (_cliente.Numero != string.Empty)
						{
							cliente_endereco += ", " + _cliente.Numero;
						}

						cliente_bairro = _cliente.Bairro;

						//_dsoftBd.ClienteEndereco(cliente, out cliente_endereco, out cliente_bairro);

						lbEndereco.Text = cliente_endereco + Environment.NewLine;
						lbEndereco.Text += cliente_bairro;

						if (Terminal.MapasOnline)
						{
							CarregarMapa();
						}
					}

					tbEntregador.Text = recurso.ToString();

					if (recurso.ToString() != string.Empty)
					{
						Recurso r = new Recurso();

						r.Codigo = recurso;

						if (_dsoftBd.CarregarDadosRecurso(r))
						{
							lbRecurso.Text = r.Nome;
						}
					}

					if (situacao == 'A' || situacao == 'N')
					{
						tbEntregador.ReadOnly = false;
						tbEntregador.Clear();

						tbEntregador.Focus();

						btSaida.Enabled = true;
						btEntrega.Enabled = false;
						btCancelar.Enabled = true;

						if (situacao == 'A')
						{
							btPagar.Enabled = true;
						}
						else
						{
							btPagar.Enabled = false;
						}
					}
					else if (situacao == 'S' || situacao == 'O')
					{
						btSaida.Enabled = true;

						btSaida.Text = "Retornar - F2";

						btEntrega.Enabled = true;

						tbEntregador.ReadOnly = true;
						btCancelar.Enabled = false;

						if (situacao == 'S')
						{
							btPagar.Enabled = true;
						}
						else
						{
							btPagar.Enabled = false;
						}
					}
					else if (situacao == 'E' || situacao == 'P')
					{
						btSaida.Enabled = false;

						btEntrega.Enabled = true;

						btEntrega.Text = "Retornar - F3";

						tbEntregador.ReadOnly = true;
						btCancelar.Enabled = false;

						if (situacao == 'E')
						{
							btPagar.Enabled = true;
						}
						else
						{
							btPagar.Enabled = false;
						}
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void CarregarMapa()
		{
			if (Terminal.MapasOnline && _emitente != null)
			{
				string origem = "";
				string destino;
				string estado;

				origem = string.Format("{0}, {1} - {2} - {3} - {4}", _emitente.Logradouro, _emitente.Numero, _emitente.Bairro, _emitente.Municipio, _emitente.Uf.Substring(0, 2));

				if (_cliente.Estado.Length > 2)
				{
					estado = _cliente.Estado.Substring(0, 2);
				}
				else
				{
					estado = _cliente.Estado;
				}

				destino = string.Format("{0}, {1} - {2} - {3} - {4}", _cliente.Endereco, _cliente.Numero, _cliente.Bairro, _cliente.Cidade, estado);

				string mapa = "<!DOCTYPE html>" +
										"<html> " +
										"<head> " +
										"   <meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\"/> " +
										"   <title>Google Maps API v3 Directions Example</title> " +
										"   <script type=\"text/javascript\" " +
										"           src=\"http://maps.google.com/maps/api/js?sensor=false\"></script>" +
										"</head> " +
										"<body style=\"font-family: Arial; font-size: 12px;\"> " +
										"   <div style=\"width: 400px;\">" +
										"     <div id=\"map\" style=\"width: 380px; height: 240px; float: left;\"></div> " +
										"     <div id=\"panel\" style=\"width: 380px; float: right;\"></div> " +
										"   </div>" +
										"   <script type=\"text/javascript\"> " +
										"     var directionsService = new google.maps.DirectionsService();" +
										"     var directionsDisplay = new google.maps.DirectionsRenderer();" +
										"     var map = new google.maps.Map(document.getElementById('map'), {" +
										"       zoom:7," +
										"       mapTypeId: google.maps.MapTypeId.ROADMAP" +
										"     });" +
										"     directionsDisplay.setMap(map);" +
										"     directionsDisplay.setPanel(document.getElementById('panel'));" +
										"     var request = {" +
										"       origin: '" + origem + "', " +
										"       destination: '" + destino + "'," +
										"       travelMode: google.maps.DirectionsTravelMode.DRIVING" +
										"     };" +
										"     directionsService.route(request, function(response, status) {" +
										"       if (status == google.maps.DirectionsStatus.OK) {" +
										"         directionsDisplay.setDirections(response);" +
										"       }" +
										"     });" +
										"   </script> " +
										"</body> " +
										"</html>";

				try
				{
					wbMap.Navigate("about:blank");

					if (wbMap.Document != null)
					{
						wbMap.Document.Write(string.Empty);
					}

					wbMap.DocumentText = mapa;
				}
				catch (Exception e)
				{
					DSoftLogger.Logger.Instance.Error(e);
				}
			}
		}

		private void CarregarPedidosAnteriores()
		{
			int ultimo;
			int.TryParse(dgEntregas[0, 0].Value.ToString(), out ultimo);

			if (ultimo > 0)
			{
				DataSet ds = new DataSet();
				_dsoftBd.CarregarPedidos(ds, ultimo);

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					_pedidos.Rows.Add(dr.ItemArray);
				}

				dgEntregas.Sort(dgEntregas.Columns[0], ListSortDirection.Ascending);

				Util.Pintar(ref dgEntregas);
			}
		}

		private bool ConfirmarEntregador()
		{
			int entregador;

			if (tbEntregador.Text == string.Empty)
			{
				lbRecurso.Text = "Entregador não informado!";

				return false;
			}
			else
			{
				if (!int.TryParse(tbEntregador.Text, out entregador))
				{
					MessageBox.Show("Campo 'entregador' deve ser numérico!");

					tbEntregador.SelectAll();

					tbEntregador.Focus();

					return false;
				}

				Recurso recurso = new Recurso();

				recurso.Codigo = entregador;

				if (_dsoftBd.CarregarDadosRecurso(recurso))
				{
					//if (recurso.Tipo != 'E')
					//{
					//    MessageBox.Show("Campo 'entregador' inválido!");

					//    textBox5.SelectAll();

					//    textBox5.Focus();

					//    return false;
					//}

					RecursoTipo recurso_tipo = new RecursoTipo();

					recurso_tipo.Codigo = recurso.Tipo;

					if (!_dsoftBd.CarregarRecursoTipo(recurso_tipo))
					{
						MessageBox.Show("Erro ao carregar tipo de recurso!", this.Text);

						tbEntregador.SelectAll();

						tbEntregador.Focus();

						return false;
					}

					if (!recurso_tipo.Entrega)
					{
						MessageBox.Show("Recurso não está habilitado para fazer entregas!", this.Text);

						tbEntregador.SelectAll();

						tbEntregador.Focus();

						return false;
					}

					if (recurso.Situacao == 'B')
					{
						MessageBox.Show("Entregador bloqueado!");

						tbEntregador.SelectAll();

						tbEntregador.Focus();

						return false;
					}
					else if (recurso.Situacao == 'C')
					{
						MessageBox.Show("Entregador cancelado!");

						tbEntregador.SelectAll();

						tbEntregador.Focus();

						return false;
					}

					lbRecurso.Text = recurso.Nome;

					return true;
				}
				else
				{
					MessageBox.Show("Entregador não encontrado!");

					tbEntregador.SelectAll();

					tbEntregador.Focus();

					return false;
				}
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			int indice;
			int.TryParse(dgEntregas.CurrentRow.Cells["indice"].Value.ToString(), out indice);

			if (indice > 0)
			{
				CarregarPedido(indice);
			}
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CarregarPedido(int.Parse(dgEntregas.CurrentRow.Cells["indice"].Value.ToString()));
			}
		}

		private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
		{
			if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
			{
				if (dgEntregas.Rows.Count >= 100)
				{
					if (dgEntregas.FirstDisplayedScrollingRowIndex < 3)
					{
						CarregarPedidosAnteriores();
					}
				}
			}
		}

		private void Entrega()
		{
			int pedido;

			if (tbPedido.Text == string.Empty)
			{
				MessageBox.Show("Campo 'pedido' deve ser preenchido!");

				tbPedido.Focus();

				return;
			}

			if (!int.TryParse(tbPedido.Text, out pedido))
			{
				MessageBox.Show("Campo 'pedido' deve ser numérico!");

				tbPedido.SelectAll();

				tbPedido.Focus();

				return;
			}

			try
			{
				if (btEntrega.Text == "&Entregue - F3")
				{
					if (_dsoftBd.EntregaPedido(pedido, _usuario.Autorizado))
					{
						Atualizar();

						CarregarPedido(pedido);
					}
					else
					{
						tbPedido.SelectAll();

						tbPedido.Focus();
					}
				}
				else
				{
					if (_dsoftBd.RetornaPedido(pedido, _usuario.Autorizado))
					{
						Atualizar();

						CarregarPedido(pedido);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return;
			}
		}

		private void entregarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Entrega();
		}

		private void entregasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFiltroEntregasCliente form = new frmFiltroEntregasCliente(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void entregasPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFiltroEntregasPeriodo form = new frmFiltroEntregasPeriodo(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void frmEntregas_Load(object sender, EventArgs e)
		{
			if (!Terminal.MapasOnline)
			{
				wbMap.Visible = false;
			}
			else
			{
				dgEntregas.Size = new Size(dgEntregas.Width - wbMap.Width, dgEntregas.Height);
			}

			Atualizar();

			List<Emitente> emitentes = _dsoftBd.CarregarEmitentes();

			if (emitentes != null && emitentes.Count > 0)
			{
				_emitente = emitentes[0];
			}

			LimparCampos();

			if (NumeroPedido > 0)
			{
				CarregarPedido(NumeroPedido);
			}
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void lbCliente_Click(object sender, EventArgs e)
		{
		}

		private void LimparCampos()
		{
			tbPedido.Clear();
			textBox2.Clear();
			textBox3.Clear();

			textBox4.Clear();
			tbEntregador.Clear();
			tbDetalhes.Text = string.Empty;

			lbCliente.Text = string.Empty;
			lbRecurso.Text = string.Empty;
			lbEndereco.Text = string.Empty;

			textBox4.ReadOnly = true;
			tbEntregador.ReadOnly = true;

			tbHoraPedido.Visible = false;
			tbHoraSaida.Visible = false;
			tbHoraEntrega.Visible = false;

			btSaida.Text = "&Saída - F2";
			btEntrega.Text = "&Entregue - F3";
			btCancelar.Enabled = false;
			btPagar.Enabled = false;

			groupBox1.Focus();

			tbPedido.Focus();
		}

		private void llAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Atualizar();
		}

		private void Pagar()
		{
			int pedido;
			int.TryParse(tbPedido.Text, out pedido);

			if (pedido < 1)
			{
				return;
			}

			CaixaSimples form = new CaixaSimples(_dsoftBd, _usuario, _pedido);

			StringBuilder builder = new StringBuilder();

			foreach (ItemPedido item in _pedido.ItensPedido)
			{
				builder.AppendLine(item.ToString());

				foreach (ItemAdicional adicional in item.ItensAdicionais)
				{
					builder.AppendLine(adicional.ToString());
				}

				if (item.Observacao != string.Empty)
				{
					builder.AppendLine(item.Observacao);
				}
			}

			if (_pedido.TaxaDeEntrega > 0)
			{
				builder.AppendLine("TAXA DE ENTREGA R$ " + _pedido.TaxaDeEntrega.ToString("##,##0.00"));
			}

			form.Referencia = builder.ToString();

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				LimparCampos();
				Atualizar();

				dgEntregas.Focus();
			}
		}

		private void Saida()
		{
			int pedido;
			int recurso;

			try
			{
				if (btSaida.Text == "&Saída - F2")
				{
					if (tbPedido.Text == string.Empty)
					{
						MessageBox.Show("Campo 'pedido' deve ser preenchido!");

						tbPedido.Focus();

						return;
					}

					if (!int.TryParse(tbPedido.Text, out pedido))
					{
						MessageBox.Show("Campo 'pedido' deve ser numérico!");

						tbPedido.SelectAll();

						tbPedido.Focus();

						return;
					}

					if (tbEntregador.Text == string.Empty)
					{
						MessageBox.Show("Campo 'entregador' deve ser preenchido!");

						tbEntregador.Focus();

						return;
					}

					if (!int.TryParse(tbEntregador.Text, out recurso))
					{
						MessageBox.Show("Campo 'entregador' deve ser numérico!");

						tbEntregador.SelectAll();

						tbEntregador.Focus();

						return;
					}

					if (!ConfirmarEntregador())
					{
						return;
					}

					if (_dsoftBd.SaidaPedido(pedido, recurso, _usuario.Autorizado))
					{
						if (RegrasDeNegocio.Instance.Ramo == "LOJA" && MessageBox.Show("Imprime demonstrativo de entrega?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
						//    frmRelatorio form = new frmRelatorio();

						//    demEntrega report = new demEntrega();

						//    form.Text = "Demonstrativo de Entrega";

						//    string DadosFilial;

						//    DadosFilial = Filial.Nome + "   CNPJ: " + Filial.Cnpj + "  IE: " + Filial.IE + Environment.NewLine;
						//    DadosFilial += Filial.Endereco + " - " + Filial.Bairro + " - " + Filial.Cidade + " / " + Filial.Estado + "   ";
						//    DadosFilial += "TEL: " + Filial.Telefone;

						//    report.ParameterFields["Filial"].CurrentValues.AddValue(DadosFilial);
						//    report.ParameterFields["pedido"].CurrentValues.AddValue(pedido);

						////	form.crystalReportViewer1.ReportSource = report;

						//    form.Show();
						}

						Atualizar();

						CarregarPedido(int.Parse(tbPedido.Text));
					}
					else
					{
						tbPedido.SelectAll();

						tbPedido.Focus();
					}
				}
				else
				{
					if (tbPedido.Text == string.Empty)
					{
						MessageBox.Show("Campo 'pedido' deve ser preenchido!");

						tbPedido.Focus();

						return;
					}

					if (!int.TryParse(tbPedido.Text, out pedido))
					{
						MessageBox.Show("Campo 'pedido' deve ser numérico!");

						tbPedido.SelectAll();

						tbPedido.Focus();

						return;
					}

					if (_dsoftBd.RetornaPedido(pedido, _usuario.Autorizado))
					{
						Atualizar();

						CarregarPedido(pedido);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				int num_pedido;

				if (tbPedido.Text != string.Empty && e.KeyChar == (char)Keys.Enter)
				{
					if (!int.TryParse(tbPedido.Text, out num_pedido))
					{
						MessageBox.Show("Campo deve ser numérico!");

						tbPedido.SelectAll();

						tbPedido.Focus();

						return;
					}

					if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
					{
						int comanda = num_pedido;
						num_pedido = 0;
						int contador = 0;

						while (num_pedido == 0)
						{
							num_pedido = _dsoftBd.PedidoPorComanda(comanda, DateTime.Today.AddDays(contador));

							if (++contador > 3)
							{
								break;
							}
						}

						if (num_pedido == 0)
						{
							num_pedido = comanda;
						}
					}

					if (!CarregarPedido(num_pedido))
					{
						tbPedido.SelectAll();

						tbPedido.Focus();
					}
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{

				if (ConfirmarEntregador())
				{
					btSaida.Focus();
				}
				else
				{
					tbEntregador.SelectAll();
					tbEntregador.Focus();
				}
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Saida();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			ReimprimirPedido();
		}

		private void ReimprimirPedido()
		{
			if (_pedido == null)
			{
				return;
			}

			if (RegrasDeNegocio.Instance.Ramo == "PIZZARIA" || RegrasDeNegocio.Instance.Ramo == "ESCOLA")
			{
				Caixa caixa = new Caixa();

				caixa.Codigo = Caixa.Numero;
				caixa.Descricao = _dsoftBd.CaixaDescricao(caixa.Codigo);

				Impressora.ImprimirPedido(_pedido, caixa, _usuario.Autorizado, _dsoftBd, false, Terminal.Impressora());

				if (Terminal.Imprime2Via())
				{
					Impressora.ImprimirPedido(_pedido, caixa, _usuario.Autorizado, _dsoftBd, false, Terminal.Impressora());
				}
			}
			else
			{
				DemPedido dem = new DemPedido();
				dem.Gerar(_dsoftBd, _pedido);
			}
		}

		#endregion Methods
	}
}