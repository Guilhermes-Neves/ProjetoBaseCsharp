require "time"

task :specs do
  time = Time.now.utc.iso8601.tr(":", "")
  report = "--format html --out=log/report_#{time}.html"
  sh "cucumber #{report}"
end

task :specsWithTag, [:tags]  do |task, args|
  time = Time.now.utc.iso8601.tr(":", "")
  report = "--format html --out=log/report_#{time}.html"
  sh "cucumber #{args[:tags]} #{report}"
end