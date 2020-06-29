require "pg"

class Database
  def up_ope(operadora)
    connection = PG.connect(host: "WIN-DSP-BANCO01",
                            port: "5433", 
                            dbname: "pack_web_packup_val", 
                            user: "postgres", 
                            password: "abc123!")
    connection.exec("UPDATE pkw090496.operadora_de_maquina set nova_operadora = 'true' where nome = '#{operadora}';")
  end

  def deletar_estab(estabelecimento)
    connection = PG.connect(host: "WIN-DSP-BANCO01",
                            port: "5433", 
                            dbname: "pack_web_packup_val", 
                            user: "postgres", 
                            password: "abc123!")
    connection.exec("DELETE from pkw090496.estabelecimento where numero = '#{estabelecimento}';")
  end
end

