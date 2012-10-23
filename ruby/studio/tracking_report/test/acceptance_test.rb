require_relative "test_helper"

class AcceptanceTest < Test::Unit::TestCase

  def setup
    @entries = []
    @stream = FakeStream.new
  end

  def test_one_entry_gives_one_row
    given_searches a_search(text: "foo")

    report_rows_count_equals 1
  end

  def test_two_searches_on_same_term_are_counted_twice
    given_searches a_search(text: "foo"),
                   a_search(text: "foo")

    report_rows_equals a_row(search_text: "foo", count: 2)
  end
  
  def test_different_searches_are_counted_separately
    given_searches a_search(text: "foo"),
                   a_search(text: "foo"),
                   a_search(text: "bar")

    report_rows_equals a_row(search_text: "foo", count: 2),
                       a_row(search_text: "bar", count: 1)
  end

  def test_click_is_related_to_an_search
    given_searches a_search(text: "foo")
    given_clicks a_click(text: "foo")

    report_rows_equals a_row(search_text: "foo", count: 1, clicks: 1, click_per_user: 1)
  end

  def test_clicks_from_same_user_are_counted_once
    given_searches a_search(text: "foo")
    given_clicks a_click(text: "foo", user: "john"),
                 a_click(text: "foo", user: "john"),
                 a_click(text: "foo", user: "bob")

    report_rows_equals a_row(search_text: "foo", count: 1, clicks: 3, click_per_user: 2)
  end

  private

  def run_report
    report = Report.new
    @entries.each { |entry| report.process entry }
    report.print @stream
  end

  def a_search(values)
    LogEntry.new({type: :search}.merge(values))
  end

  def a_click(values)
    LogEntry.new({type: :click}.merge(values))
  end

  def a_row(values)
    {clicks: 0, click_per_user: 0}.merge values
  end

  def given_searches(* searches)
    searches.each { |search| @entries << search }
  end

  def given_clicks(* clicks)
    clicks.each { |click| @entries << click }
  end

  def report_rows_count_equals(value)
    run_report
    assert_equal value, @stream.lines.count
  end

  def report_rows_equals(* rows)
    run_report
    assert_equal rows, @stream.lines
  end
end