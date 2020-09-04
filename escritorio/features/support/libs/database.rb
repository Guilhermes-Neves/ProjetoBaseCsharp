require "mysql2"

class DataBase
  @database_connect = Mysql2::Client.new(
    host: "142.44.247.200",
    username: "styllus_hlg",
    password: "HLGST2019st!@#",
    database: "hlg_integrador",
  )

  def up_order(orderId)
    @database_connect.query("UPDATE hlg_integrador.Pedidos set StatusPagamento = '5' WHERE PedidoId = '#{orderId}';")
  end

  def up_cashback(cashbackId, value)
    Mysql2::Client.new(
      host: "142.44.247.200",
      username: "styllus_hlg",
      password: "HLGST2019st!@#",
      database: "hlg_integrador",
    ).query("UPDATE hlg_integrador.Cashback set Saldo = '#{value}' WHERE CashbackId = '#{cashbackId}';")
  end
end
