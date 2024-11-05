CC = g++
CCFLAGS = -std=c++17
PROJECTDIR = .
INCLUDEDIR = /include
DYNAMICLIB = coreCpp.dylib
DYNAMICLIBFLAGS = -fpic -shared

all: build

SOURCES = \
    $(PROJECTDIR)/Model/DllInterface.cc \
    $(PROJECTDIR)/Model/Model.cc \
    $(PROJECTDIR)/Model/Validator.cc

HEADERS = \
    $(PROJECTDIR)/Model/Arithmetic.h \
    $(PROJECTDIR)/Model/DllInterface.h \
    $(PROJECTDIR)/Model/Model.h \
    $(PROJECTDIR)/Model/Validator.h


$(DYNAMICLIB):
	- mkdir .$(INCLUDEDIR)
	$(CC) -std=c++17 $(DYNAMICLIBFLAGS) $(SOURCES) -I$(INCLUDEDIR) -o $@
	cp $(HEADERS) .$(INCLUDEDIR)
	mv $@ .$(INCLUDEDIR)/

build: $(DYNAMICLIB)
	cd src && dotnet run

clean:
	@rm $(INCLUDEDIR)/$(DYNAMICLIB)

.PHONY: clean
