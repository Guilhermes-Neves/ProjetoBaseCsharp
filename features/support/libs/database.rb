require "mysql2"

class DataBase
  def update_order(orderId)
    @client.query("UPDATE hlg_integrador.Pedidos set StatusPagamento = '5' WHERE PedidoId = '#{orderId}';")
  end
end
