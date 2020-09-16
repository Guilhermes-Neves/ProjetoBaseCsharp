require "mysql2"

class DataBase
  def delete_category(category)
    Mysql2::Client.new(
      host: "142.44.247.200",
      username: "styllus_hlg",
      password: "HLGST2019st!@#",
      database: "hlg_integrador",
    ).query("DELETE FROM hlg_integrador.EadCategorias WHERE Nome = '#{category}';")
  end

  def insert_category(name, slug)
    Mysql2::Client.new(
      host: "142.44.247.200",
      username: "styllus_hlg",
      password: "HLGST2019st!@#",
      database: "hlg_integrador",
    ).query("INSERT INTO hlg_integrador.EadCategorias
      (Nome, SLUG)
      VALUES('#{name}', '#{slug}');")
  end

  def delete_shipping(cost)
    Mysql2::Client.new(
      host: "142.44.247.200",
      username: "styllus_hlg",
      password: "HLGST2019st!@#",
      database: "hlg_integrador",
    ).query("DELETE FROM hlg_integrador.Fretes
      WHERE Preco  = #{cost};")
  end
end
