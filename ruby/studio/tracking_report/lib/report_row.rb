require 'set'

class ReportRow < Hash
  def initialize(fields)
    self.merge! fields
    @sessions = Set.new
  end

  def process(entry)
    self[:count] += 1 if entry.is_search?
    if entry.is_click?
      self[:clicks] += 1
      @sessions << entry[:user]
    end
  end

  def print(stream)
    stream.print self.merge(click_per_user: @sessions.count)
  end
end