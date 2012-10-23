require_relative 'report_row'

class Report
  def initialize
    @rows = {}
  end

  def process(entry)
    row = find_row entry
    if row.nil?
      row = create_row entry
    end
    row.process entry if !row.nil?
  end

  def print(stream)
    @rows.each { |k, v| v.print stream }
  end

  private

  def find_row(entry)
    @rows[entry[:text]]
  end

  def create_row(entry)
    row = ReportRow.new({search_text: entry[:text], count: 0, clicks: 0, click_per_user: 0})
    @rows[entry[:text]] = row
  end
end