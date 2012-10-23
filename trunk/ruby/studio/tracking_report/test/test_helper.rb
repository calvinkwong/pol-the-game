require "test/unit"
require_relative "../lib/report"
require_relative "../lib/log_entry"

class FakeStream
  def initialize
    @lines = []
  end

  def lines
    @lines
  end

  def print(row)
    @lines << row
  end
end

