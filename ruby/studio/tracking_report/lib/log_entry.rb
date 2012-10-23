class LogEntry < Hash
  def initialize(fields)
    self.merge! fields
  end

  def is_click?
    self[:type] == :click
  end

  def is_search?
    self[:type] == :search
  end
end